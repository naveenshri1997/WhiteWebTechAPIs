using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WhiteWebTech.API.Entities;

namespace WhiteWebTech.API.DataAccess;

public partial class WhiteDbContext : DbContext
{
    public WhiteDbContext()
    {
    }

    public WhiteDbContext(DbContextOptions<WhiteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<NewQuery> NewQueries { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Applicant");

            entity.Property(e => e.ApplicantDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Cv)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("CV");

            entity.HasOne(d => d.Job).WithMany()
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Applicant_Jobs");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.CreateTime)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IsActive)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<NewQuery>(entity =>
        {
            entity.ToTable("NewQuery");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Query)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
