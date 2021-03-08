using DKT.Core.Admin.BusinessObjects;
using DKT.Data.EntityFramework.Admin.Configuration;
using DKT.Data.EntityFramework.Admin.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DKT.Data.EntityFramework
{
    public class AdminDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
