using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HRMS.Models
{
    public partial class HRMSContext : DbContext
    {
        public HRMSContext()
        {

        }
        public HRMSContext(DbContextOptions<HRMSContext> options) : base(options)
        {

        }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<ExperienceTable> ExperienceTables { get; set; }
        public virtual DbSet<LogDetail> LogDetails { get; set; }
        public virtual DbSet<Recruitment> Recruitments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<Sp_Recruitment> Sp_Recruitments { get; set; }
        public object Sp_Recruitment { get; internal set; }
        public virtual DbSet<JobRequest> JobRequests { get; set; }
        public virtual DbSet<EmpDetails> EmpDetailss { get; set; }
        public virtual DbSet<EmpBankDetails> EmpBankDetailss { get; set; }
        public virtual DbSet<EmpEduDetails> EmpEduDetailss { get; set; }
        public virtual DbSet<EmpProfDetails> EmpProfDetailss { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-INV0E8FA;Database=HRMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.RegistrationId);

                entity.ToTable("Admin_User");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExperienceTable>(entity =>
            {
                entity.ToTable("Experience_Table");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Experience)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");
            });

            modelBuilder.Entity<LogDetail>(entity =>
            {
                entity.ToTable("LogDetail");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LoginDateTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Recruitment>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("Recruitment");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Technology).IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User_Credentials");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserType");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserType1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserType");
            });
            
            modelBuilder.Entity<JobRequest>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("JobRequest");

                entity.Property(e => e.RecruitmentId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Technology)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Experience)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hrremark)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            
            modelBuilder.Entity<EmpDetails>(entity =>
            {
                entity.HasKey(e => e.EmpProfId);

                entity.ToTable("EmpDetails");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Father_SpouseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritialStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AadhaarNo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PanCardNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmgContactName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelationWithEmp)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.EmgContactNo)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.C_AddL1)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.C_AddL2)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.C_City)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.C_State)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.C_State)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.C_Zip)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.C_Country)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.P_AddL1)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.P_AddL2)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.P_City)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.P_City)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.P_State)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.P_Zip)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.P_Country)
                  .HasMaxLength(50)
                  .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Doj).HasColumnType("datetime");

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmpBankDetails>(entity =>
            {
                entity.HasKey(e => e.BankId);

                entity.ToTable("EmpBankDetails");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfAccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IfscCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UanNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmpEduDetails>(entity =>
            {
                entity.HasKey(e => e.EduId);

                entity.ToTable("EmpEduDetails");

                entity.Property(e => e.Degree)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.University)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PercentageGrade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Specification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                                    .HasMaxLength(50)
                                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DFrom).HasColumnType("datetime");

                entity.Property(e => e.DTo).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                
            });
            
            modelBuilder.Entity<EmpProfDetails>(entity =>
            {
                entity.HasKey(e => e.ProfId);

                entity.ToTable("EmpProfDetails");

                entity.Property(e => e.PrvOrganizationName)
               .HasMaxLength(50)
               .IsUnicode(false);

                entity.Property(e => e.PrvDesignation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrvJobLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrvWorkDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrvManagerNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                               .HasMaxLength(50)
                               .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });
            
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
