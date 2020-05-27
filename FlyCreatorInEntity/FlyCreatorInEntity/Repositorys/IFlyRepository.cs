using FlyCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Repositorys
{
    public interface IFlyRepository
    {
        Task<IEnumerable<Fly>> GetAllFlysAsync();

        Task<Fly> GetFlyAsync(int id);

        void AddFly(Fly fly);

        Task<bool> SaveChangesAsync();
    }
}
