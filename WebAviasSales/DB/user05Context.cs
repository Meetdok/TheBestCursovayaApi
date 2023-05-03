using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebTheBestCursach.Models;

namespace WebTheBestCursach.DB
{
    public partial class user05Context : DbContext
    {
        public user05Context()
        {
        }

        public user05Context(DbContextOptions<user05Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AduccationForm> AduccationForms { get; set; } = null!;
        public virtual DbSet<Documet> Documets { get; set; } = null!;
        public virtual DbSet<EducationForm> EducationForms { get; set; } = null!;
        public virtual DbSet<EducationFormBySpeciality> EducationFormBySpecialities { get; set; } = null!;
        public virtual DbSet<LoginPage> LoginPages { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.200.35;database=user05;user=user05;password=44084");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AduccationForm>(entity =>
            {
                entity.HasKey(e => e.DefaultListId)
                    .HasName("PK_DefaultList");

                entity.ToTable("AduccationForm");

                entity.Property(e => e.DefaultListId).HasColumnName("DefaultListID");

                entity.Property(e => e.DocumentsId).HasColumnName("DocumentsID");

                entity.Property(e => e.MedicalPolicy).HasColumnName("Medical_policy");

                entity.Property(e => e.PrimingCertificate).HasColumnName("Priming_certificate");

                entity.Property(e => e.RegistrationCertificate).HasColumnName("Registration_certificate");

                entity.Property(e => e.SpecialityId).HasColumnName("SpecialityID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Documents)
                    .WithMany(p => p.AduccationForms)
                    .HasForeignKey(d => d.DocumentsId)
                    .HasConstraintName("FK_DefaultList_Documets");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.AduccationForms)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_AduccationForm_Speciality");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AduccationForms)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AduccationForm_User");
            });

            modelBuilder.Entity<Documet>(entity =>
            {
                entity.Property(e => e.DocumetId).HasColumnName("DocumetID");

                entity.Property(e => e.BirthdayDate).HasColumnType("date");

                entity.Property(e => e.Inn).HasColumnName("INN");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<EducationForm>(entity =>
            {
                entity.ToTable("EducationForm");

                entity.Property(e => e.EducationFormId).HasColumnName("EducationFormID");
            });

            modelBuilder.Entity<EducationFormBySpeciality>(entity =>
            {
                entity.HasKey(e => e.EducationFormBySpecialitiesId);

                entity.Property(e => e.EducationFormBySpecialitiesId).HasColumnName("EducationFormBySpecialitiesID");

                entity.HasOne(d => d.EducationForm)
                    .WithMany(p => p.EducationFormBySpecialities)
                    .HasForeignKey(d => d.EducationFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationFormBySpecialities_EducationForm");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.EducationFormBySpecialities)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("FK_EducationFormBySpecialities_Speciality");
            });

            modelBuilder.Entity<LoginPage>(entity =>
            {
                entity.ToTable("LoginPage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");

                entity.Property(e => e.SpecialityId).HasColumnName("SpecialityID");

                entity.Property(e => e.EducationFormId).HasColumnName("EducationFormID");

                entity.HasOne(d => d.EducationForm)
                    .WithMany(p => p.Specialities)
                    .HasForeignKey(d => d.EducationFormId)
                    .HasConstraintName("FK_Speciality_EducationForm");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_LoginPage");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
