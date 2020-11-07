using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace joolochu.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        #region DbSet
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<District> Districts{ get; set; }
        public virtual DbSet<Mark> Marks{ get; set; }
        public virtual DbSet<Order> Orders{ get; set; }
        public virtual DbSet<Point> Points{ get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<TypeCar> TypeCars { get; set; }
        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<Village> Villages{ get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
