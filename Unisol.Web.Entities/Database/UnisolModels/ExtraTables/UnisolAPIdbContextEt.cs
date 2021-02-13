using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Unisol.Web.Entities.Database.UnisolModels.ExtraTables
{
    public partial class UnisolAPIdbContextEt : DbContext
    {
        public UnisolAPIdbContextEt()
        {
        }

        public UnisolAPIdbContextEt(DbContextOptions<UnisolAPIdbContextEt> options)
            : base(options)
        {
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=UnisolUOEdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PclaimDetail>(entity =>
            {
                entity.ToTable("PClaimDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IpearningRef)
                    .HasColumnName("IPEarningRef")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PayAccount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pcref)
                    .HasColumnName("PCRef")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Units)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PclaimRates>(entity =>
            {
                entity.ToTable("PClaimRates");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CertType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PayAccount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Personnel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Rdate).HasColumnType("datetime");

                entity.Property(e => e.Units)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
		}
    }
}
