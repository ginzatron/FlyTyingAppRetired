using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using FlyCreator.DTOs;
using FlyCreator.Models;
using FlyCreator.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlyCreatorInEntity.Controllers
{
    [Route("api/material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _materialsRepo;
        private readonly FlyDbContext _flyContext;

        public MaterialController(IMaterialRepository materialsRepo, FlyDbContext flyContext)
        {
            _materialsRepo = materialsRepo;
            _flyContext = flyContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterials()
        {
            return Ok(await _materialsRepo.GetAllMaterialsAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            return Ok(await _materialsRepo.GetMaterialAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostMaterial(MaterialDTO material)
        {
            // auto map this converstion somehow, constructor with other repositories?
            var classification = material.FlyClassificationId != null ? await _flyContext.FlyClassifications.FindAsync(material.FlyClassificationId) : null;
            var materialCategory = await _flyContext.MaterialCategories.FindAsync(material.MaterialCategoryId);
            var newMaterial = new Material() { Name = material.Name, FlyClassification = classification, MaterialCategory = materialCategory };

            _materialsRepo.AddMaterial(newMaterial);
            await _materialsRepo.SaveChangesAsync();

            await _materialsRepo.GetMaterialAsync(newMaterial.Id);

            return CreatedAtAction("GetMaterial", new { id = newMaterial.Id }, newMaterial);
        }

        [HttpPost("{material_id}/options")]
        public async Task<IActionResult> PostMaterialOption(string material_id, IEnumerable<MaterialOptionDTO> options)
        {
            if (options.Count() == 0)
                return Ok();

            var materialId = int.Parse(material_id);

            if (!await _flyContext.Materials.AnyAsync(x => x.Id == materialId))
                return NotFound();

            _materialsRepo.AddMaterialOptions(materialId, options);

            await _materialsRepo.SaveChangesAsync();

           return CreatedAtAction("GetMaterial",new { id = material_id});
            //return Ok();
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutMaterial(int id, Material material)
        //{
        //    if (id != material.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _flyContext.Entry(material).State = EntityState.Modified;
        //    await _flyContext.SaveChangesAsync();

        //    return Ok(material);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Material>> DeleteMaterial(int id)
        //{
        //    var materialToDelete = await _flyContext.Materials.FindAsync(id);
        //    if (materialToDelete == null)
        //    {
        //        return NotFound();
        //    }

        //    _flyContext.Materials.Remove(materialToDelete);
        //    await _flyContext.SaveChangesAsync();

        //    return materialToDelete;
        //}


    }
}