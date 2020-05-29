using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using FlyCreator.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace FlyCreator.Controllers
{
    [Route("api/admin")]
    [ApiController]
    //[Authorize]
    public class AdminController : ControllerBase
    {
        // TODOs: create UsersContextrepository

        private readonly UsersContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UsersContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("token")]
        public async Task GetToken(GoogleToken token)
        {
            var gottenT = token.token;

            // make a config
            var audienceList = new List<string>()
            {
                "733506587937-chja2snvhu4cppd6ug4fnrp0bo2aqt8q.apps.googleusercontent.com"
            };

            // first check audience 
            var payload = GoogleJsonWebSignature.ValidateAsync(gottenT, new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = audienceList
            }).Result;

            // then check issuer
            var issuerClaim = (payload.Issuer == "accounts.google.com" || payload.Issuer == "https://accounts.google.com");

            var tokenVerified = (payload != null && issuerClaim == true);

            if (tokenVerified)
            {
                // need something other than email, maybe sub
                var registeredUser = await _userManager.FindByEmailAsync(payload.Email);

                //  if not registered, register them
                if (registeredUser == null)
                {
                    var newUser = new Registration()
                    {
                        Email = payload.Email
                    };

                    await RegisterUser(newUser);
                }
                else
                    await LogInUser(registeredUser);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(Registration newUser)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = newUser.Email,
                    Email = newUser.Email
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                    await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInUser(IdentityUser registeredUser)
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignInAsync(registeredUser, isPersistent: false);

                //if (result.Succeeded)
               return Ok();
            }

            return NotFound();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogOutUser()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }
    }
}