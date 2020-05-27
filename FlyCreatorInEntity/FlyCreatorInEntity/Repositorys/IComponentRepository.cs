using FlyCreator.DTOs;
using FlyCreator.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Repositorys
{
    public interface IComponentRepository
    {
        Task<IEnumerable<Component>> GetComponentsOnFlyAsync(int flyId);

        Task UpdateComponentsOnFly(int flyId, IEnumerable<ComponentDTO> componentDTOs);

        Task<bool> SaveChangesAsync();
    }
}
