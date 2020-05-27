using FlyCreator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DataLayer
{
    public class MaterialsContext : DbContext
    {
        public MaterialsContext(DbContextOptions<MaterialsContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<FlyClassification> FlyClassifications { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<MaterialOption> MaterialOptions { get; set; }
    }
}
