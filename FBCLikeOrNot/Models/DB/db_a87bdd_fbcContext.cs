using System;
using FBCLikeOrNot.Models.ParameterViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FBCLikeOrNot.Models.DB
{
    public partial class db_a87bdd_fbcContext : DbContext
    {
        public db_a87bdd_fbcContext()
        {
        }

        public db_a87bdd_fbcContext(DbContextOptions<db_a87bdd_fbcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpleadosPosadum> EmpleadosPosada { get; set; }
        public virtual DbSet<GrievanceMail> GrievanceMails { get; set; }
        public virtual DbSet<LikeDevice> LikeDevices { get; set; }
        public virtual DbSet<LikeLoggedreaction> LikeLoggedreactions { get; set; }
        public virtual DbSet<LikeQuestion> LikeQuestions { get; set; }
        public virtual DbSet<LikeQuestionServicesLog> LikeQuestionServicesLogs { get; set; }
        public virtual DbSet<LikeReaction> LikeReactions { get; set; }
        public virtual DbSet<LikeService> LikeServices { get; set; }
        public virtual DbSet<LikeUser> LikeUsers { get; set; }
        public virtual DbSet<LikeUserRole> LikeUserRoles { get; set; }
        public virtual DbSet<LikeUserRolesServiceAccess> LikeUserRolesServiceAccesses { get; set; }
        public virtual DbSet<UserGrievance> UserGrievances { get; set; }
        public DbSet<SessionUserViewModel> GetLoginUserSP { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL8002.site4now.net;Initial Catalog=db_a87bdd_fbc;User Id=db_a87bdd_fbc_admin;Password=Mit3ch2017!#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<SessionUserViewModel>();
            modelBuilder.Entity<SessionUserViewModel>();  //register stored procedure.

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmpleadosPosadum>(entity =>
            {
                entity.ToTable("EmpleadosPosada", "fbc");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.Bum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bum");

                entity.Property(e => e.CheckDate)
                    .HasColumnType("datetime")
                    .HasColumnName("checkDate");

                entity.Property(e => e.Idrh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("idrh");

                entity.Property(e => e.Ischecked)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ischecked");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreDepartamento)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre_departamento");

                entity.Property(e => e.NombrePuesto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_puesto");

                entity.Property(e => e.NumeroDepartamento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_departamento");

                entity.Property(e => e.NumeroPuesto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_puesto");
            });

            modelBuilder.Entity<GrievanceMail>(entity =>
            {
                entity.ToTable("GrievanceMail");

                entity.Property(e => e.Creadate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.FactoryLocation)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.FactoryName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.GrievanceType)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.PersonName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LikeDevice>(entity =>
            {
                entity.HasKey(e => e.Iddevice)
                    .HasName("PK__LikeDevi__CC60D9ED342EAE67");

                entity.ToTable("LikeDevices", "fbc");

                entity.Property(e => e.Createbydevice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createdatedevice).HasColumnType("datetime");

                entity.Property(e => e.Editbydevice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdatedevice).HasColumnType("datetime");

                entity.Property(e => e.IdService).HasColumnName("Id_service");

                entity.Property(e => e.Namedevice)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.LikeDevices)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LikeDevic__Id_se__6E01572D");
            });

            modelBuilder.Entity<LikeLoggedreaction>(entity =>
            {
                entity.HasKey(e => e.Idlog)
                    .HasName("PK__LikeLogg__15975BD0B72C0C87");

                entity.ToTable("LikeLoggedreactions", "fbc");

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.IdDevice).HasColumnName("Id_device");

                entity.Property(e => e.IdReaction).HasColumnName("Id_reaction");

                entity.HasOne(d => d.IdDeviceNavigation)
                    .WithMany(p => p.LikeLoggedreactions)
                    .HasForeignKey(d => d.IdDevice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LikeLogge__Id_de__70DDC3D8");

                entity.HasOne(d => d.IdReactionNavigation)
                    .WithMany(p => p.LikeLoggedreactions)
                    .HasForeignKey(d => d.IdReaction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LikeLogge__Id_re__71D1E811");
            });

            modelBuilder.Entity<LikeQuestion>(entity =>
            {
                entity.HasKey(e => e.Idquestion)
                    .HasName("PK__LikeQues__7667BA52DF5AA742");

                entity.ToTable("LikeQuestions", "fbc");

                entity.Property(e => e.Createbyquestion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createdatequestion).HasColumnType("datetime");

                entity.Property(e => e.Descriptionquestion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Editbyquestion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdatequestion).HasColumnType("datetime");
            });

            modelBuilder.Entity<LikeQuestionServicesLog>(entity =>
            {
                entity.ToTable("LikeQuestionServicesLog", "fbc");

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.IdQuestion).HasColumnName("Id_question");

                entity.Property(e => e.IdService).HasColumnName("Id_service");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.LikeQuestionServicesLogs)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LikeQuest__Id_qu__74AE54BC");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.LikeQuestionServicesLogs)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LikeQuest__Id_se__75A278F5");
            });

            modelBuilder.Entity<LikeReaction>(entity =>
            {
                entity.HasKey(e => e.Idreaction)
                    .HasName("PK__LikeReac__AE439E2BD1C0EB99");

                entity.ToTable("LikeReactions", "fbc");

                entity.Property(e => e.Createdatereaction).HasColumnType("datetime");

                entity.Property(e => e.Namereaction)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LikeService>(entity =>
            {
                entity.HasKey(e => e.Idservice)
                    .HasName("PK__LikeServ__1C5A4A4C58213874");

                entity.ToTable("LikeServices", "fbc");

                entity.Property(e => e.Createbyservice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createdateservice).HasColumnType("datetime");

                entity.Property(e => e.Editbyservice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdateservice).HasColumnType("datetime");

                entity.Property(e => e.Nameservice)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LikeUser>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PK__LikeUser__778B8921AA7B3422");

                entity.ToTable("LikeUsers", "fbc");

                entity.Property(e => e.Createbyuser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createdateuser).HasColumnType("datetime");

                entity.Property(e => e.Editbyuser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdateuser).HasColumnType("datetime");

                entity.Property(e => e.Employeenumberuser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdRole).HasColumnName("Id_Role");

                entity.Property(e => e.Lastnameuser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nameuser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Passworduser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.LikeUsers)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LikeUsers__Id_Ro__628FA481");
            });

            modelBuilder.Entity<LikeUserRole>(entity =>
            {
                entity.HasKey(e => e.IdUserrole)
                    .HasName("PK__LikeUser__04C62BC34899572D");

                entity.ToTable("LikeUserRoles", "fbc");

                entity.Property(e => e.Createbyrole)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Createdaterole).HasColumnType("datetime");

                entity.Property(e => e.Editbyrole)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdaterole).HasColumnType("datetime");

                entity.Property(e => e.Namerole)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LikeUserRolesServiceAccess>(entity =>
            {
                entity.HasKey(e => e.IdUserroleaccess)
                    .HasName("PK__LikeUser__17F252F34A68C75C");

                entity.ToTable("LikeUserRolesServiceAccess", "fbc");

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.IdRole).HasColumnName("Id_Role");

                entity.Property(e => e.IdService).HasColumnName("Id_Service");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.LikeUserRolesServiceAccesses)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LikeUserR__Id_Ro__656C112C");
            });

            modelBuilder.Entity<UserGrievance>(entity =>
            {
                entity.ToTable("UserGrievance");

                entity.Property(e => e.Createdate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
