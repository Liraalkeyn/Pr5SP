using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pr5SP.Models;

namespace Pr5SP.Context;

public partial class Pr5SpContext : DbContext
{
    public Pr5SpContext()
    {
    }

    public Pr5SpContext(DbContextOptions<Pr5SpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Exhibit> Exhibits { get; set; }

    public virtual DbSet<TypeOfExhibit> TypeOfExhibits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=Pr5SP;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("Country_pkey");

            entity.ToTable("Country");

            entity.Property(e => e.CountryId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("countryID");
            entity.Property(e => e.NameOfCountry)
                .HasMaxLength(50)
                .HasColumnName("nameOfCountry");
        });

        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.HasKey(e => e.ExhibitId).HasName("Exhibit_pkey");

            entity.ToTable("Exhibit");

            entity.Property(e => e.ExhibitId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ExhibitID");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.NameOfExhibit)
                .HasMaxLength(150)
                .HasColumnName("nameOfExhibit");
            entity.Property(e => e.TypeOfExhibit).HasColumnName("typeOfExhibit");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("countryFK");

            entity.HasOne(d => d.TypeOfExhibitNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.TypeOfExhibit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TypeOfExhibitFK");
        });

        modelBuilder.Entity<TypeOfExhibit>(entity =>
        {
            entity.HasKey(e => e.TypeOfExhibitId).HasName("TypeOfExhibit_pkey");

            entity.ToTable("TypeOfExhibit");

            entity.Property(e => e.TypeOfExhibitId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("TypeOfExhibitID");
            entity.Property(e => e.NameOfType)
                .HasMaxLength(50)
                .HasColumnName("nameOfType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
