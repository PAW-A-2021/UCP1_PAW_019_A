using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_019_A.Models
{
    public partial class RentPSContext : DbContext
    {
        public RentPSContext()
        {
        }

        public RentPSContext(DbContextOptions<RentPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Penyewa> Penyewas { get; set; }
        public virtual DbSet<PlayStation> PlayStations { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Penyewa>(entity =>
            {
                entity.HasKey(e => e.IdPenyewa);

                entity.ToTable("Penyewa");

                entity.Property(e => e.IdPenyewa)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Penyewa");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomorTelpon)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("Nomor_Telpon");
            });

            modelBuilder.Entity<PlayStation>(entity =>
            {
                entity.HasKey(e => e.IdPlayStation);

                entity.ToTable("PlayStation");

                entity.Property(e => e.IdPlayStation)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PlayStation");

                entity.Property(e => e.JenisPlayStation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_PlayStation");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => e.IdRental);

                entity.ToTable("Rental");

                entity.Property(e => e.IdRental)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Rental");

                entity.Property(e => e.HargaSewa).HasColumnName("Harga_Sewa");

                entity.Property(e => e.TglPeminjaman)
                    .HasColumnType("datetime")
                    .HasColumnName("Tgl_Peminjaman");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.HargaSewa).HasColumnName("Harga_Sewa");

                entity.Property(e => e.IdPenyewa).HasColumnName("ID_Penyewa");

                entity.Property(e => e.IdPlayStation).HasColumnName("ID_PlayStation");

                entity.Property(e => e.IdRental).HasColumnName("ID_Rental");

                entity.HasOne(d => d.IdPenyewaNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdPenyewa)
                    .HasConstraintName("FK_Transaksi_Penyewa");

                entity.HasOne(d => d.IdPlayStationNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdPlayStation)
                    .HasConstraintName("FK_Transaksi_PlayStation");

                entity.HasOne(d => d.IdRentalNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdRental)
                    .HasConstraintName("FK_Transaksi_Rental");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
