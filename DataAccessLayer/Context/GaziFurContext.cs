using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class GaziFurContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D0MF8VI\\SQLEXPRESS;Initial Catalog=GaziFurDb;Integrated Security=True;TrustServerCertificate=True;");

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }  
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many relationship: Product can have many ProductImages
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(pi => pi.product)
                .HasForeignKey(pi => pi.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
