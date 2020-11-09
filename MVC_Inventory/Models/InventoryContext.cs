using System;
using Microsoft.EntityFrameworkCore;
using MVC_Inventory.Models;

namespace MVC_Inventory.Models
{
    public class InventoryContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=127.0.0.1;" +
                    "port=8889;" +
                    "user=root;" +
                    "password=root;" +
                    "database=mvc_inventory;";

                string version = "5.7.26";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Discontinued)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                   new Product()
                   {
                       ID = -1,
                       Name = "iPhone",
                       Quantity = 12,
                       Discontinued = 1
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -2,
                       Name = "iPad",
                       Quantity = 2,
                       Discontinued = 1
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -3,
                       Name = "iMac",
                       Quantity = 12,
                       Discontinued = 1
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -4,
                       Name = "iPod",
                       Quantity = 12,
                       Discontinued = 0
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -5,
                       Name = "Apple Watch",
                       Quantity = 4,
                       Discontinued = 1
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -6,
                       Name = "Apple Home",
                       Quantity = 20,
                       Discontinued = 1
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -7,
                       Name = "Apple Glasses",
                       Quantity = 10,
                       Discontinued = 0
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -8,
                       Name = "Airpods",
                       Quantity = 19,
                       Discontinued = 1
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -9,
                       Name = "MacBook",
                       Quantity = 7,
                       Discontinued = 1
                   }
                );
                entity.HasData(
                   new Product()
                   {
                       ID = -10,
                       Name = "Mac Mini",
                       Quantity = 7,
                       Discontinued = 1
                   }
                );
            });
        }
    }
}
