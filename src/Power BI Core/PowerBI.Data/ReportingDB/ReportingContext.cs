using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PowerBI.Data.ReportingDB
{
    public partial class ReportingContext : DbContext
    {
        public ReportingContext()
        {
        }

        public ReportingContext(DbContextOptions<ReportingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportRole> ReportRole { get; set; }
        public virtual DbSet<ReportVisual> ReportVisual { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report", "Reporting");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PowerBIGroupId).HasColumnName("PowerBIGroupId");

                entity.Property(e => e.PowerBIReportId).HasColumnName("PowerBIReportId");

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReportRole>(entity =>
            {
                entity.ToTable("ReportRole", "Reporting");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportRole)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportRole_Report");
            });

            modelBuilder.Entity<ReportVisual>(entity =>
            {
                entity.HasKey(d => d.ReportVisualId);

                entity.ToTable("ReportVisual", "Reporting");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.Property(e => e.ReportVisualId).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VisualName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportVisual)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportVisual_Report");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
