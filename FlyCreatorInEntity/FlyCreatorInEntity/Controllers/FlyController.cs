﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using FlyCreator.DTOs;
using FlyCreator.Models;
using FlyCreator.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlyCreatorInEntity.Controllers
{
    [Route("api/fly")]
    [ApiController]
    [Authorize]
    public class FlyController : ControllerBase
    {
        private readonly IFlyRepository _flyRepo;
        private UserManager<AppUser> _userManager;

        public FlyController(IFlyRepository flyRepo, UserManager<AppUser> userManager)
        {
            _flyRepo = flyRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlys()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var flys = await _flyRepo.GetAllFlysAsync();
            
            return Ok(flys.Where(f => f.UserId.ToString() == user.Id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFly(int id)
        {
            var fly = await _flyRepo.GetFlyAsync(id);

            var returnFly = convertFlytoReturnFlyDTO(fly);

            return Ok(returnFly);
        }

        private ReturnFlyDTO convertFlytoReturnFlyDTO(Fly fly)
        {
            var returnComponents = new List<ReturnComponentDTO>();

            foreach (var component in fly.Components)
            {
                returnComponents.Add(ConvertComponentToReturnComponentDTO(component));
            }

            return new ReturnFlyDTO()
            {
                flyId = fly.Id,
                flyName = fly.Name,
                flyClassificationId = fly.ClassificationId,
                flyClassification = fly.Classification.Classification,
                components = returnComponents
            };
        }

        private ReturnComponentDTO ConvertComponentToReturnComponentDTO(Component component)
        {
            return new ReturnComponentDTO()
            {
                componentId = component.Id,
                materialId = component.MaterialId,
                materialName = component.Material.Name,
                materialCategoryId = component.Material.MaterialCategory.Id,
                materialCategory = component.Material.MaterialCategory.Name,
                materialOptionId = component.MaterialOptionId,
                materialOption = component.MaterialOption.Value,
                sectionId = component.SectionId,
                section = component.Section.Name
            };
        }

        [HttpPost]
        public async Task<IActionResult> CreateFly(FlyDTO fly)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var newFly = new Fly() {
                Name = fly.Name,
                ClassificationId = Int32.Parse(fly.FlyClassificationId),
                DateCreated = DateTime.Now,
                LastEdited = DateTime.Now,
                UserId = new Guid(user.Id)
            };
            
            _flyRepo.AddFly(newFly);

            await _flyRepo.SaveChangesAsync();

            await _flyRepo.GetFlyAsync(newFly.Id);

            return CreatedAtAction("GetFly", new { id = newFly.Id }, newFly);
        }
    }
}