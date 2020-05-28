using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using FlyCreator.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        //[HttpPost("token")]
        //public async Task GetToken(JwtBearerDefaults token)
        //{
        //    var gottenT = token;
        //}

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

                var result = await _userManager.CreateAsync(user, newUser.Password);

                if (result.Succeeded)
                    await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInUser(LogIn login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
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