using FlyCreator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DataLayer
{
    public class FlyDbContext : DbContext
    {
        public FlyDbContext(DbContextOptions<FlyDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<UserNote> UserNotes { get; set; }
        public DbSet<Fly> Flys { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<FlyClassification> FlyClassifications { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<MaterialOption> MaterialOptions { get; set; }
    }
}
