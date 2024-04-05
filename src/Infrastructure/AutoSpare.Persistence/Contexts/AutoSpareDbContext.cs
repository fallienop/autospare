using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Common;
using AutoSpare.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Contexts
{
    public class AutoSpareDbContext : DbContext
    {

        public const string ProductSchema = "Product";

        public AutoSpareDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>().ToTable(nameof(Make), ProductSchema);
            modelBuilder.Entity<Model>().ToTable(nameof(Domain.Entities.Product.Model), ProductSchema);
            modelBuilder.Entity<Part>().ToTable(nameof(Part), ProductSchema);
            modelBuilder.Entity<Part>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Category>()
        .HasMany(c => c.Subcategories)
        .WithOne(c => c.ParentCategory)
        .HasForeignKey(c => c.ParentCategoryId)
        .OnDelete(DeleteBehavior.Restrict);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.UtcNow
                } ;

            }
            var resp= await base.SaveChangesAsync(cancellationToken);
            return resp;


        }

    }
}
