using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectEMS.DL
{
    public partial class RiseProjectContext : DbContext
    {
        public RiseProjectContext()
        {
        }

        public RiseProjectContext(DbContextOptions<RiseProjectContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<EmpProjTable> EmpProjTable { get; set; }
        public virtual DbSet<EmployeeManagerTable> EmployeeManagerTable { get; set; }
        public virtual DbSet<EmployeesTable> EmployeesTable { get; set; }
        public virtual DbSet<ProjectTable> ProjectTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=kishan;Initial Catalog=RiseProject;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpProjTable>(entity =>
            {
                entity.HasKey(e => e.EmpProId);

                entity.Property(e => e.EmpProId).HasColumnName("EmpPro_id");

                entity.Property(e => e.EId).HasColumnName("E_id");

                entity.Property(e => e.PId).HasColumnName("P_id");

                entity.HasOne(d => d.E)
                    .WithMany(p => p.EmpProjTable)
                    .HasForeignKey(d => d.EId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpProjTable_EmployeesTable");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.EmpProjTable)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpProjTable_ProjectTable");
            });

            modelBuilder.Entity<EmployeeManagerTable>(entity =>
            {
               
                entity.HasKey(e => e.MEId);

                entity.Property(e => e.MEId).HasColumnName("ME_id");

                entity.Property(e => e.EId).HasColumnName("E_id");

                entity.Property(e => e.MId).HasColumnName("M_id");

                entity.HasOne(d => d.E)
                    .WithMany()
                    .HasForeignKey(d => d.EId)
                    .HasConstraintName("FK_EmployeeManagerTable_EmployeesTable");

                entity.HasOne(d => d.M)
                    .WithMany()
                    .HasForeignKey(d => d.MId)
                    .HasConstraintName("FK_EmployeeManagerTable_EmployeesTable1");
            });

            modelBuilder.Entity<EmployeesTable>(entity =>
            {
                entity.HasKey(e => e.EId);

                entity.Property(e => e.EId).HasColumnName("E_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JoinningDate)
                .HasColumnName("JoinningDate")
                .HasColumnType("date");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectTable>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.Property(e => e.PId).HasColumnName("P_id");

                entity.Property(e => e.Pdetails).HasMaxLength(350);

                entity.Property(e => e.PendDate)
                    .HasColumnName("PEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PstartDate)
                    .HasColumnName("PStartDate")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
