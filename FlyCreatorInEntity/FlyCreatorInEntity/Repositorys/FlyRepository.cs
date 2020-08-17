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

    }
}
