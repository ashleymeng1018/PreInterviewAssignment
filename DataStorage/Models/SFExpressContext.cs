using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataStorage.Models
{
    public partial class SFExpressContext : DbContext
    {
        public SFExpressContext()
        {
        }

        public SFExpressContext(DbContextOptions<SFExpressContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sfexpress.database.windows.net;Database=SFExpress;User ID=SFExpress;Password=Assignment@2021;Encrypt=True;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HiredDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
