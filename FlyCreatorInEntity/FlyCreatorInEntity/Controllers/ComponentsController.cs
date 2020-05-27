using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlyCreator.DataLayer;
using FlyCreator.Models;
using FlyCreator.DTOs;
using FlyCreator.Repositorys;

namespace FlyCreatorInEntity.Controllers
{
    [Route("api/fly/{fly_Id}/components")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly IComponentRepository _componentRepo;
        private readonly IFlyRepository _flyRepo;


        public ComponentsController(IComponentRepository componentRepo, IFlyRepository flyRepo)
        {
            _componentRepo = componentRepo;
            _flyRepo = flyRepo;
        }

        [HttpPost]
        public async Task<IActionResult> EditFlyComponents(string fly_Id, IEnumerable<ComponentDTO> components)
        {
            var flyid = int.Parse(fly_Id);

            await _componentRepo.UpdateComponentsOnFly(flyid, components);

            await _componentRepo.SaveChangesAsync();

            var updatedFly = await _flyRepo.GetFlyAsync(flyid);

            return Ok(updatedFly);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        //{
        //    var flys = await _context.Components
        //        .Include(s => s.Section)
        //        .Include(m => m.Material)
        //        .ToListAsync();

        //    return flys;
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Component>> GetComponent(int id)
        //{
        //    var component = await _context.Components.FindAsync(id);

        //    if (component == null)
        //    {
        //        return NotFound();
        //    }

        //    return component;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutComponent(int id, Component component)
        //{
        //    if (id != component.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(component).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ComponentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        ////[HttpPost]
        ////public async Task<ActionResult<Component>> PostComponent(ComponentDTO component)
        ////{
        ////    var section = await _context.Sections.FindAsync(component.SectionId);
        ////    var material = await _context.Materials.FindAsync(component.MaterialId);

        ////    //var newComponent = new Component() { FlyId = component.FlyId, Section = section, Material = material, DateCreated = DateTime.Now };
        ////    _context.Components.Add(newComponent);
        ////    await _context.SaveChangesAsync();

        ////    return CreatedAtAction("GetComponent", new { id = newComponent.Id }, newComponent);
        ////}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Component>> DeleteComponent(int id)
        //{
        //    var component = await _context.Components.FindAsync(id);
        //    if (component == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Components.Remove(component);
        //    await _context.SaveChangesAsync();

        //    return component;
        //}

        //private bool ComponentExists(int id)
        //{
        //    return _context.Components.Any(e => e.Id == id);
        //}
    }
}
