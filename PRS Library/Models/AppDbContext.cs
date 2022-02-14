using Microsoft.EntityFrameworkCore;
using PRS_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Library {
    public class AppDbContext : DbContext {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestLine> RequestLines { get; set; }


        public AppDbContext() {
        }

        public AppDbContext(DbContextOptions<AppDbContext> fred) : base(fred) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=PRSLibrary;trusted_connection=true;");

            }
        }

        //unique username code for Users and Code for Vendors
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<User>(
                fred => fred.HasIndex(fred => fred.Username)
                .IsUnique(true));
            builder.Entity<Vendor>(
                fred => fred.HasIndex(fred => fred.Code)
                .IsUnique(true));
            builder.Entity<Product>(
                fred => fred.HasIndex(fred => fred.PartNbr)
                .IsUnique(true));
            builder.Entity<Product>(
                fred => fred.HasIndex(fred => fred.Id)
                .IsUnique(true));
        }
    }
}
