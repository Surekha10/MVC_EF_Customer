using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Example.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext():base("constr")
        {

        }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>().MapToStoredProcedures();
            modelBuilder.Entity<OrderModel>().MapToStoredProcedures();
            modelBuilder.Entity<EmployeeModel>().MapToStoredProcedures();
            modelBuilder.Entity<ProductModel>().ToTable("tbl_products");
            modelBuilder.Entity<ProductModel>().HasKey(p => p.ProductID);
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ProductModel>().Property(p => p.ProductPrice).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p=>p.ProductAddedDate).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            modelBuilder.Entity<ProductModel>().MapToStoredProcedures();
        }
    }
}