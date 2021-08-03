using Microsoft.EntityFrameworkCore;
using LA.Domain;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.IO;
//using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LA.Data
{
    public class LayoutContext: DbContext
    {
        private readonly string _connectionString;

        public DbSet<Layout> Events { get; set; }

        #region CTOR
        public LayoutContext()
        { }

        public LayoutContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=Database/layout.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
