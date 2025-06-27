using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hospital_App.Domain;

public partial class HospitalDbContext : DbContext
{
    private string path;

    public HospitalDbContext()
    {
        string basePath = AppContext.BaseDirectory;
        path = Path.Combine(basePath, "HospitalDB.db");
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
        string basePath = AppContext.BaseDirectory;
        path = Path.Combine(basePath, "HospitalDB.db");
    }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderMedicine> OrderMedicines { get; set; }

    public virtual DbSet<User> Users { get; set; }
    //DataSource=C:\\Users\\Claudiu\\Desktop\\GithubRepos\\iss-project-csharp\\Hospital App\\
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource="+path);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.ToTable("Medicine");

            entity.HasIndex(e => e.Name, "IX_Medicine_Name").IsUnique();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<OrderMedicine>(entity =>
        {
            entity.ToTable("OrderMedicine");

            entity.Property(e => e.Id).HasColumnName("ID ");
            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Medicine).WithMany(p => p.OrderMedicines).HasForeignKey(d => d.MedicineId);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderMedicines).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.Name, "IX_User_Name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
