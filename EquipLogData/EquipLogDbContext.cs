using EquipLog.Data.SQL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Reflection;

namespace EquipLogData
{
    public class EquipLogDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public EquipLogDbContext(DbContextOptions<EquipLogDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentParts> EquipmentParts { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tickets>()
                        .HasOne(t => t.Equipment)
                        .WithMany(e => e.Tickets)
                        .HasForeignKey(t => t.EquipmentId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EquipmentParts>()
                        .Property(e => e.Price)
                        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Tickets>()
            .HasOne(t => t.Technician)
            .WithMany(x=>x.Tickets)
            .HasForeignKey(t => t.TechnicianId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipment>()
                .HasOne(x => x.Category)
                .WithMany(c => c.Equipments)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            Assembly assemblyConfig = Assembly.GetAssembly(typeof(EquipLogDbContext)) ?? Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyConfig);

            base.OnModelCreating(modelBuilder);
        }
    }
}
