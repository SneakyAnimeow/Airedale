using Airedale.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Airedale.Database.Context;

public partial class AiredaleDbContext : DbContext {
    public AiredaleDbContext() {
    }

    public AiredaleDbContext(DbContextOptions<AiredaleDbContext> options)
        : base(options) {
    }

    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Service> Services { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlite("DataSource=./database.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Category>(entity => {
            entity.ToTable("Category");

            entity.HasIndex(e => e.Name, "IX_Category_Name")
                .IsUnique();
        });

        modelBuilder.Entity<Service>(entity => {
            entity.ToTable("Service");

            entity.HasIndex(e => e.Name, "IX_Service_Name")
                .IsUnique();

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<User>(entity => {
            entity.ToTable("User");

            entity.HasIndex(e => e.Name, "IX_User_Name")
                .IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}