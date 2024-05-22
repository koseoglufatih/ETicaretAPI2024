
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application;
using ZZTicaret.Domain;

namespace ZZTicaret.Persistence
{
    public class ZZTicaretContext : DbContext
    {
        public ZZTicaretContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketItem> BasketItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        ////{
        ////    modelBuilder.Entity<Product>()
        ////    .HasOne(p => p.Category)
        ////    .WithMany(c => c.Products)
        ////    .HasForeignKey(p => p.CategoryId);

        ////    modelBuilder.Entity<Order>()
        ////        .HasOne(o => o.User)
        ////        .WithMany(u => u.Orders)
        ////        .HasForeignKey(o => o.UserId);

        ////    modelBuilder.Entity<OrderDetail>()
        ////        .HasOne(od => od.Order)
        ////        .WithMany(o => o.OrderDetails)
        ////        .HasForeignKey(od => od.OrderId);

        ////    modelBuilder.Entity<OrderDetail>()
        ////        .HasOne(od => od.Product)
        ////        .WithMany(p => p.OrderDetails)
        ////        .HasForeignKey(od => od.ProductId);

        ////    //modelBuilder.Entity<Basket>()
        ////    //    .HasOne(b => b.User)
        ////    //    .WithMany(u => u.Baskets)
        ////    //    .HasForeignKey(b => b.UserId);

        ////    modelBuilder.Entity<BasketItem>()
        ////        .HasOne(bi => bi.Basket)
        ////        .WithMany(b => b.BasketItems)
        ////        .HasForeignKey(bi => bi.BasketId);

        ////    modelBuilder.Entity<BasketItem>()
        ////        .HasOne(bi => bi.Product)
        ////        .WithMany(p => p.BasketItems)
        ////        .HasForeignKey(bi => bi.ProductId);

        ////    base.OnModelCreating(modelBuilder);
        //}








        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ZZTicaret;Integrated Security=True;TrustServerCertificate=True");
    }
}
