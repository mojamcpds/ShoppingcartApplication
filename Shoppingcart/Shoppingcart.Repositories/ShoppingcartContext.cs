using Microsoft.AspNet.Identity.EntityFramework;
using Shoppingcart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories
{
    public class ShoppingcartContext:DbContext
    {
        public ShoppingcartContext()
            : base("DefaultConnection")
        {
        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTitle> ProductTitles { get; set; }
        public DbSet<Size> Sizes { get; set; }


       
        public virtual int Commit()
        {
           return base.SaveChanges();
        }

        public virtual async Task<int> CommitAsync()
        {
            return await base.SaveChangesAsync();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<ProductTitle>().Property(p => p.Id).HasColumnName("ProductTitleId");
            modelBuilder.Entity<Size>().Property(p => p.Id).HasColumnName("SizeId");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Colour>().Property(p => p.Id).HasColumnName("ColourId");
            modelBuilder.Entity<Brand>().Property(p => p.Id).HasColumnName("BrandId");
            modelBuilder.Entity<Category>().Property(p => p.Id).HasColumnName("CategoryId");


        }
    }
}
