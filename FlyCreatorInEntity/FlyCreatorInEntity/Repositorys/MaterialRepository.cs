//using FlyCreator.DataLayer;
//using FlyCreator.DTOs;
//using FlyCreator.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FlyCreator.Repositorys
//{
//    public class MaterialRepository : IMaterialRepository
//    {
//        private readonly FlyDbContext _context;

//        public MaterialRepository(FlyDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
//        {
//            return await _context.Materials
//                .Include(m => m.FlyClassification)
//                .Include(m => m.MaterialCategory)
//                .ToListAsync();
//        }

//        public async Task<Material> GetMaterialAsync(Guid id)
//        {
//            var material = await _context.Materials
//                .Include(m => m.FlyClassification)
//                .Include(m => m.MaterialCategory)
//                .Include(m => m.MaterialOptions)
//                .FirstOrDefaultAsync(m => m.Id == id);

//            return material;
//        }

//        public void AddMaterial(Material material)
//        {
//            _context.Materials.Add(material);
//        }

//        public void AddMaterialOptions(int materialId, IEnumerable<MaterialOptionDTO> options)
//        {
//            foreach (var option in options)
//            {
//                var newMaterialOption = new MaterialOption() { Discriminator = option.Discriminator, MaterialId = materialId, Value = option.Value };
//                _context.MaterialOptions.Add(newMaterialOption);
//            }
//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return (await _context.SaveChangesAsync() > 0);
//        }
//    }
//}