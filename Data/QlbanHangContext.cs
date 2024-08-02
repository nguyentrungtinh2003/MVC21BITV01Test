using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC21BITV01Test.Data;

public partial class QlbanHangContext : DbContext
{
    public QlbanHangContext()
    {
    }

    public QlbanHangContext(DbContextOptions<QlbanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThanhPho> ThanhPhos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=QLBanHang;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp });

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK_Orders");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayLapHd)
                .HasColumnType("datetime")
                .HasColumnName("NgayLapHD");
            entity.Property(e => e.NgayNhanHang).HasColumnType("datetime");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK_Customers");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.DienThoai).HasMaxLength(24);
            entity.Property(e => e.TenCty).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.MaDn)
                .HasMaxLength(50)
                .HasColumnName("MaDN");
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.NgayNv).HasColumnName("NgayNV");
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK_Products");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.TenSp)
                .HasMaxLength(40)
                .HasColumnName("TenSP");
        });

        modelBuilder.Entity<ThanhPho>(entity =>
        {
            entity.HasKey(e => e.MaThanhPho);

            entity.ToTable("ThanhPho");

            entity.Property(e => e.TenThanhPho).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
