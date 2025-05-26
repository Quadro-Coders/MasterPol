using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterPol.Models;

public partial class Wsr1DexDemoContext : DbContext
{
    public Wsr1DexDemoContext()
    {
    }

    public Wsr1DexDemoContext(DbContextOptions<Wsr1DexDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<History> Histories { get; set; }



    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.10.151;Initial Catalog=wsr1_dex_demo;User ID=wsr-1;Password=\"$cYm*kL$Ny5QP#\";Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("History");

            entity.Property(e => e.Count)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Partner).WithMany(p => p.Histories)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Partners");

            entity.HasOne(d => d.Product).WithMany(p => p.Histories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Products");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.Property(e => e.DirectorPhone).HasMaxLength(20);
            entity.Property(e => e.Inn).HasColumnName("INN");
            entity.Property(e => e.Type).HasMaxLength(5);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.MinPrice).HasColumnType("money");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductTypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
