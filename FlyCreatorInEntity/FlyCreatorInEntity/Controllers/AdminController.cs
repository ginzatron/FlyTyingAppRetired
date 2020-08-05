using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using FlyCreator.Interfaces;
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

namespace FlyCreator.Controllers
{
    [Route("api/admin")]
    [ApiController]
    //[Authorize]
    public class AdminController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenValidator _validator;

        public AdminController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenValidator validator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _validator = validator;
        }

        [HttpPost("token")]
        public async Task GetToken(ExternalLogInToken token)
        {
            var payload = _validator.GeneratePayload(token);
            var isValidToken = _validator.ValidateToken(payload);

            if (isValidToken)
            {
                // need something other than email, maybe sub
                var registeredUser = await _userManager.FindByEmailAsync(payload.Email);

                //  if not registered, register them
                if (registeredUser == null)
                {
                    var newUser = new Registration()
                    {
                        Email = payload.Email,
                        SubjectId = payload.Subject
                    };

                    await RegisterUser(newUser);
                }
                else
                    await LogInUser(registeredUser);
            }
        }

        [HttpPost("register")]
        private async Task<IActionResult> RegisterUser(Registration newUser)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = newUser.Email,
                    Email = newUser.Email,
                    SubjectId = newUser.SubjectId
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                    await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInUser(AppUser registeredUser)
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