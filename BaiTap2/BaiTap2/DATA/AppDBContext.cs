using BaiTap2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BaiTap2.DATA
{
    public class AppDBContext:DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AllowAccess> AllowAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithOne(r => r.User)
            .HasForeignKey<User>(u => u.RoleId);

            modelBuilder.Entity<AllowAccess>()
                .HasOne(a => a.Role)
                .WithMany()
                .HasForeignKey(a => a.RoleId);
        }
    }
}
