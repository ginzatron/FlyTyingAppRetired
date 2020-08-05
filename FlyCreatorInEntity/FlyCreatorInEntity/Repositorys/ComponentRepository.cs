using FlyCreator.DataLayer;
using FlyCreator.DTOs;
using FlyCreator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Repositorys
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly FlyDbContext _context;

        public ComponentRepository(FlyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Component>> GetComponentsOnFlyAsync(int flyId)
        {
            return  await _context.Components
                .Where(c => c.FlyId == flyId)
                .ToListAsync();
        }

        public async Task UpdateComponentsOnFly(int flyId, IEnumerable<ComponentDTO> componentDTOs)
        {
            var existingComponents = await GetComponentsOnFlyAsync(flyId);
            var updatedComponentIds = componentDTOs.Select(c => c.Id);

            foreach (var component in existingComponents)
            {
                // if the component is not in the returned list of components we remove it
                if (!updatedComponentIds.Contains(component.Id))
                    _context.Components.Remove(component);
            }


            foreach (var componentDTO in componentDTOs)
            {
                var component = await _context.Components.FindAsync(componentDTO.Id);

                // if a returned component is not already on the fly, we make a new one
                if (component == null)
                {
                    var newComponent = new Component()
                    {
                        FlyId = flyId,
                        Material = await _context.Materials.FindAsync(componentDTO.MaterialId),
                        MaterialOption = await _context.MaterialOptions.FindAsync(componentDTO.MaterialOptionId),
                        Section = await _context.Sections.FindAsync(componentDTO.SectionId),
                        DateCreated = DateTime.Now,
                        LastEdited = DateTime.Now
                    };
                    await _context.Components.AddAsync(newComponent);
                }
                // if the component exists, we update the properties
                else
                {
                    component.Material = await _context.Materials.FindAsync(componentDTO.MaterialId);
                    component.MaterialOption = await _context.MaterialOptions.FindAsync(componentDTO.MaterialOptionId);
                    component.Section = await _context.Sections.FindAsync(componentDTO.SectionId);
                    component.LastEdited = DateTime.Now;
                }
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
