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
                if (!updatedComponentIds.Contains(component.Id))
                    _context.Components.Remove(component);
            }


            foreach (var componentDTO in componentDTOs)
            {
                var component = await _context.Components.FindAsync(componentDTO.Id);

                if (component == null)
                {
                    var newComponent = new Component()
                    {
                        FlyId = flyId,
                        MaterialId = componentDTO.MaterialId,
                        MaterialOptionId = componentDTO.MaterialOptionId,
                        SectionId = componentDTO.SectionId,
                        DateCreated = DateTime.Now,
                        LastEdited = DateTime.Now
                    };
                    await _context.Components.AddAsync(newComponent);
                }
                else
                {
                    component.MaterialId = componentDTO.MaterialId;
                    component.MaterialOptionId = componentDTO.MaterialOptionId;
                    component.SectionId = componentDTO.SectionId;
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
