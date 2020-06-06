using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using FlyCreator.DTOs;
using FlyCreator.Models;
using FlyCreator.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlyCreatorInEntity.Controllers
{
    [Route("api/fly")]
    [ApiController]
    //[Authorize]
    public class FlyController : ControllerBase
    {
        private readonly IFlyRepository _flyRepo;

        public FlyController(IFlyRepository flyRepo)
        {
            _flyRepo = flyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlys()
        {
            return Ok(await _flyRepo.GetAllFlysAsync());
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
            var newFly = new Fly() {
                Name = fly.Name,
                ClassificationId = fly.FlyClassificationId,
                DateCreated = DateTime.Now,
                LastEdited = DateTime.Now,
                // TODO will be the signed in user
                //UserId = 1
            };
            
            _flyRepo.AddFly(newFly);

            await _flyRepo.SaveChangesAsync();

            await _flyRepo.GetFlyAsync(newFly.Id);

            return CreatedAtAction("GetFly", new { id = newFly.Id }, newFly);
        }
    }
}