using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace findmyhomeApi.Models
{
    public partial class findmyhomeContext : DbContext
    {
        public virtual DbSet<BienImmo> BienImmo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=FMH\SQLEXPRESS;Database=findmyhome;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BienImmo>(entity =>
            {
                entity.Property(e => e.Adresse).HasMaxLength(50);

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Soustitre).HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.Titre).IsRequired();

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.Property(e => e.TypeBien).HasMaxLength(10);

                entity.Property(e => e.Ville).HasMaxLength(50);
            });
        }
    }
}