using FlyCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace FlyCreator.Models
{
    public class GoogleToken : Payload, IExternalLogInToken
    {
        public string Id_Token { get; set; }
    }
}
