using FlyCreator.DTOs;
using FlyCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Repositorys
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllMaterialsAsync();

        Task<Material> GetMaterialAsync(int id);

        void AddMaterial(Material material);

        void AddMaterialOptions(int materialId, IEnumerable<MaterialOptionDTO> options);

        Task<bool> SaveChangesAsync();
    }
}
