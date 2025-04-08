using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoiServiceCrud.Models;

public partial class CoiDbContext : DbContext
{
    public CoiDbContext()
    {
    }

    public CoiDbContext(DbContextOptions<CoiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=CoiDB;User Id=sa;Password=temPass#;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(

        );
        //modelBuilder.Entity<Product>(entity =>
        //{
        //    entity.ToTable("PRODUCTS");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.DateCreation)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime")
        //        .HasColumnName("dateCreation");
        //    entity.Property(e => e.Description).HasColumnName("description");
        //    entity.Property(e => e.Name)
        //        .HasMaxLength(150)
        //        .IsUnicode(false)
        //        .HasColumnName("name");
        //    entity.Property(e => e.Price)
        //        .HasColumnType("decimal(18, 2)")
        //        .HasColumnName("price");
        //    entity.Property(e => e.Status).HasColumnName("status");
        //});

        //OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
