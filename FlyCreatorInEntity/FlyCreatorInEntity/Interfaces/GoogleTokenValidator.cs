using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static Google.Apis.Auth.JsonWebToken;

namespace FlyCreator.Interfaces
{
    public class GoogleTokenValidator : ITokenValidator
    {
        public bool ValidateToken(IPayload payload) 
        {
            var issuerClaim = (payload.Issuer == "accounts.google.com" || payload.Issuer == "https://accounts.google.com");

            return (payload != null && issuerClaim == true);
        }

        public IPayload GeneratePayload(IExternalLogInToken token)
        {
            // make a config
            var audienceList = new List<string>()
            {
                "733506587937-chja2snvhu4cppd6ug4fnrp0bo2aqt8q.apps.googleusercontent.com"
            };

            var validation = GoogleJsonWebSignature.ValidateAsync(token.Id_Token, new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = audienceList
            }).Result;

            var googlePayload = new GooglePayload()
            {
                Email = validation.Email,
                Subject = validation.Subject,
                Issuer = validation.Issuer
            };

            return googlePayload;
        }
    }
}
