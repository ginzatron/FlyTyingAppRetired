using BlackHole.IDP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlackHole.IDP.DbContexts
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Subject)
                .IsUnique();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedConcurrencyAwareEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .OfType<IConcurrencyAware>();

            foreach (var entry in updatedConcurrencyAwareEntries)
            {
                entry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
