using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyCreator.DataLayer;
using FlyCreator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlyCreatorInEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private FlyDbContext _flyContext;

        public SectionController(FlyDbContext flyContext)
        {
            _flyContext = flyContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> GetAllSections()
        {
            return await _flyContext.Sections.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> GetSection(int id)
        {
            var section = await _flyContext.Sections.FindAsync(id);

            if (section == null)
                return NotFound();

            return section;
        }

        [HttpPost]
        public async Task<ActionResult<Section>> PostSection(Section section)
        {
            _flyContext.Sections.Add(section);
            await _flyContext.SaveChangesAsync();

            return CreatedAtAction("GetSection", new { id = section.Id }, section);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSection(Guid id, Section section)
        {
            if (id != section.Id)
            {
                return BadRequest();
            }

            _flyContext.Entry(section).State = EntityState.Modified;
            await _flyContext.SaveChangesAsync();

            return Ok(section);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Section>> DeleteSection(int id)
        {
            var sectionToDelete = await _flyContext.Sections.FindAsync(id);
            if (sectionToDelete == null)
            {
                return NotFound();
            }

            _flyContext.Sections.Remove(sectionToDelete);
            await _flyContext.SaveChangesAsync();

            return sectionToDelete;
        }
    }
}