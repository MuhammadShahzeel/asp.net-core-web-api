using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _11WebApiCRUD.Models;

public partial class StudentsWebApiDbContext : DbContext
{
    public StudentsWebApiDbContext()
    {
    }

    public StudentsWebApiDbContext(DbContextOptions<StudentsWebApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsWebApi> StudentsWebApis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Connection string is configured in Program.cs
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentGender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentsWebApi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07C882ABF0");

            entity.ToTable("StudentsWebApi");

            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.StudentGender).HasMaxLength(10);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
