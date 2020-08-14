using FlyCreator.DataLayer;
using FlyCreator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Repositorys
{
    public class FlyRepository : EfRepository<Fly>, IFlyRepository
    {
        public FlyRepository(FlyDbContext context)
            : base(context) { }

        public async Task<IEnumerable<Fly>> GetAllFlysAsync()
        {
            return await _context.Flys
                .Include(f => f.Classification)
                .ToListAsync();
        }

        public async Task<Fly> GetFlyAsync(int id)
        {
            return await _context.Flys
                .Include(f => f.Classification)
                .Include(f => f.Components)
                    .ThenInclude(c => c.Material)
                        .ThenInclude(m => m.MaterialCategory)
                .Include(f => f.Components)
                    .ThenInclude(c => c.MaterialOption)
                .Include(f => f.Components)
                    .ThenInclude(c => c.Section)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void AddFly(Fly fly)
        {
            _context.Flys.Add(fly);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); 
        }
    }
}
