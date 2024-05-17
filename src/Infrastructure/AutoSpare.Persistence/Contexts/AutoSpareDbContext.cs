using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Common;
using AutoSpare.Domain.Entities.Identity;
using AutoSpare.Domain.Entities.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Contexts
{
    public class AutoSpareDbContext : IdentityDbContext<AppUser,AppRole,string>
    {

        public const string ProductSchema = "Product";

        public AutoSpareDbContext(DbContextOptions options) : base(options)
        {
        }

   
        public DbSet<CityCode> CityCodes { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<SuggestedProduct> SuggestedProducts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>().ToTable(nameof(Make), ProductSchema);
            modelBuilder.Entity<Model>().ToTable(nameof(Domain.Entities.Product.Model), ProductSchema);
            modelBuilder.Entity<Part>().ToTable(nameof(Part), ProductSchema);
            modelBuilder.Entity<Part>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Plate>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Tire>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>()
        .HasMany(c => c.Subcategories)
        .WithOne(c => c.ParentCategory)
        .HasForeignKey(c => c.ParentCategoryId)
        .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Order>().HasMany(x=>x.OrderPart).WithOne(x => x.Order).HasForeignKey(x=>x.OrderId);
            //modelBuilder.Entity<Part>().HasMany(x=>x.OrderPart).WithOne(x=>x.Part).HasForeignKey(x=>x.PartId);
            //modelBuilder.Entity<OrderPart>().HasNoKey();


            modelBuilder.Entity<OrderPart>()
                    .HasKey(op => new { op.OrderId, op.PartId });

            modelBuilder.Entity<OrderPart>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderPart)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderPart>()
                .HasOne(op => op.Part)
                .WithMany(p => p.OrderPart)
                .HasForeignKey(op => op.PartId);
            modelBuilder.Entity<AppUser>()
           .HasMany(u => u.Orders)
           .WithOne(o => o.AppUser)
           .HasForeignKey(o => o.AppUserId)
           .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Company>().HasMany(x => x.Employees).WithOne(o => o.Company).HasForeignKey(o => o.CompanyId);
            //modelBuilder.Entity<AppUser>().HasOne(x => x.Company).WithMany(x => x.Employees).HasForeignKey(x => x.CompanyId);

            //       modelBuilder.Entity<AppUser>()
            //.HasOne(u => u.Company)           // An AppUser belongs to one Company
            //.WithMany(c => c.Employees)       // A Company can have many Employees (AppUsers)
            //.HasForeignKey(u => u.CompanyId) // Foreign key property
            //.IsRequired();                    // Make CompanyId required

            //       modelBuilder.Entity<Company>()
            //           .HasMany(c => c.Employees)       // A Company can have many Employees (AppUsers)
            //           .WithOne(u => u.Company)         // An AppUser belongs to one Company
            //           .HasForeignKey(u => u.CompanyId);

            //modelBuilder.Entity<Company>().HasMany(x => x.AppUsers).WithOne(o => o.Company).HasForeignKey(x => x.CompanyId).OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            //modelBuilder.Entity<Company>().HasMany(x=>x.AppUsers).WithOne(x=>x.Company).HasForeignKey(o => o.CompanyId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CityCode>().Property(e => e.Id)
      .ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
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
