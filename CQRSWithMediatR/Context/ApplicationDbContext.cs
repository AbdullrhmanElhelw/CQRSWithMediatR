using CQRSWithMediatR.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CQRSWithMediatR.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<EmployeeProject> EmployeeProjects => Set<EmployeeProject>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var deparmentsData = File.ReadAllText("Data/Department.json");
        var departments = JsonSerializer.Deserialize<List<Department>>(deparmentsData);

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e=>e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e=>e.Code).HasMaxLength(5).IsRequired();
            entity.HasKey(e => e.Id);

            entity
            .HasMany(e=>e.Employees)
            .WithOne(e=>e.Department)
            .HasForeignKey(e=>e.DepartmentId)
            .HasConstraintName("FK_Department_Employees");

            entity
            .HasMany(e => e.Projects)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .HasConstraintName("FK_Deparment_Projects");

            entity.HasData(departments);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(e => new { e.ProjectId, e.EmployeeId });
            entity.HasIndex(e => new { e.ProjectId, e.EmployeeId });

            entity
            .HasOne(e => e.Project)
            .WithMany(e => e.Employees)
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.NoAction);

            entity
            .HasOne(e => e.Employee)
            .WithMany(e => e.Projects)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);


        });

        base.OnModelCreating(modelBuilder);
    }
}

