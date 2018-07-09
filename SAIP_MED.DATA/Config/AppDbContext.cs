using Microsoft.EntityFrameworkCore;
using SAIP_MED.CORE.Models;

namespace SAIP_MED.DATA.Config
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=BISMARCK-PC\SQLEXPRESS;Initial Catalog=SAIP_MED_DB;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog=SAIP_MED_DB;Integrated Security=True");
        }
        
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Seguro> Seguro { get; set; }
        public DbSet<CentroRef> CentroRef { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tabla Documento
            modelBuilder.Entity<Documento>().HasKey(x => x.IdDocumento);
            modelBuilder.Entity<Documento>().HasIndex(x => x.NombreDocumento).IsUnique();
            modelBuilder.Entity<Documento>().Property(x => x.NombreDocumento).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Documento>().Property(x => x.Estado).HasDefaultValue(1).IsRequired();
            #endregion
            #region Tabla Paciente
            modelBuilder.Entity<Paciente>().HasKey(x => x.IdPaciente);
            modelBuilder.Entity<Paciente>().Property(x => x.IdDocumento).IsRequired();
            modelBuilder.Entity<Paciente>().Property(x => x.NroDocumento).HasMaxLength(12).IsRequired();
            modelBuilder.Entity<Paciente>().Property(x => x.Nombre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Paciente>().Property(x => x.Apellidos).HasMaxLength(60);
            modelBuilder.Entity<Paciente>().Property(x => x.Telefono).HasMaxLength(20);
            modelBuilder.Entity<Paciente>().Property(x => x.Direccion).HasMaxLength(200);
            modelBuilder.Entity<Paciente>().Property(x => x.Email).HasMaxLength(30);
            modelBuilder.Entity<Paciente>().Property(x => x.FechaNacimiento).IsRequired();
            modelBuilder.Entity<Paciente>().Property(x => x.Sexo).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Paciente>().Property(x => x.Estado).IsRequired().HasDefaultValue(1);
            #endregion
            #region Tabla Contacto
            modelBuilder.Entity<Contacto>().HasKey(x => x.IdContacto);
            modelBuilder.Entity<Contacto>().Property(x => x.NroDocumento).HasMaxLength(12);
            modelBuilder.Entity<Contacto>().Property(x => x.Nombre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Contacto>().Property(x => x.Apellidos).HasMaxLength(60);
            modelBuilder.Entity<Contacto>().Property(x => x.Telefono).HasMaxLength(20);
            modelBuilder.Entity<Contacto>().Property(x => x.Direccion).HasMaxLength(200);
            modelBuilder.Entity<Contacto>().Property(x => x.Email).HasMaxLength(30);
            modelBuilder.Entity<Contacto>().Property(x => x.IdPaciente).IsRequired();
            #endregion
            #region Tabla Medico
            modelBuilder.Entity<Medico>().HasKey(x => x.IdMedico);
            modelBuilder.Entity<Medico>().Property(x => x.IdDocumento).IsRequired();
            modelBuilder.Entity<Medico>().Property(x => x.NroDocumento).HasMaxLength(12).IsRequired();
            modelBuilder.Entity<Medico>().Property(x => x.Nombre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Medico>().Property(x => x.Apellidos).HasMaxLength(60);
            modelBuilder.Entity<Medico>().Property(x => x.Telefono).HasMaxLength(20);
            modelBuilder.Entity<Medico>().Property(x => x.Direccion).HasMaxLength(200);
            modelBuilder.Entity<Medico>().Property(x => x.Email).HasMaxLength(30);
            modelBuilder.Entity<Medico>().Property(x => x.IdEspecialidad).IsRequired();
            modelBuilder.Entity<Medico>().Property(x => x.Estado).IsRequired().HasDefaultValue(1);
            #endregion
            #region Tabla Empleado
            modelBuilder.Entity<Empleado>().HasKey(x => x.IdEmpleado);
            modelBuilder.Entity<Empleado>().Property(x => x.IdDocumento).IsRequired();
            modelBuilder.Entity<Empleado>().Property(x => x.NroDocumento).HasMaxLength(12).IsRequired();
            modelBuilder.Entity<Empleado>().Property(x => x.Nombre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Empleado>().Property(x => x.Apellidos).HasMaxLength(60);
            modelBuilder.Entity<Empleado>().Property(x => x.Telefono).HasMaxLength(20);
            modelBuilder.Entity<Empleado>().Property(x => x.Direccion).HasMaxLength(200);
            modelBuilder.Entity<Empleado>().Property(x => x.Email).HasMaxLength(30);
            modelBuilder.Entity<Empleado>().Property(x => x.Cargo).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Empleado>().Property(x => x.Estado).IsRequired().HasDefaultValue(1);
            #endregion
            #region Tabla Especialidad
            modelBuilder.Entity<Especialidad>().HasKey(x => x.IdEspecialidad);
            modelBuilder.Entity<Especialidad>().HasIndex(x => x.NombreEspecialidad).IsUnique();
            modelBuilder.Entity<Especialidad>().Property(x => x.NombreEspecialidad).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Especialidad>().Property(x => x.Estado).IsRequired().HasDefaultValue(1);
            #endregion
            #region Tabla Seguro
            modelBuilder.Entity<Seguro>().HasKey(x => x.IdSeguro);
            modelBuilder.Entity<Seguro>().Property(x => x.IdDocumento).IsRequired();
            modelBuilder.Entity<Seguro>().Property(x => x.NroDocumento).HasMaxLength(15).IsRequired();
            modelBuilder.Entity<Seguro>().Property(x => x.Nombre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Seguro>().Property(x => x.Apellidos).HasMaxLength(60);
            modelBuilder.Entity<Seguro>().Property(x => x.Telefono).HasMaxLength(20);
            modelBuilder.Entity<Seguro>().Property(x => x.Direccion).HasMaxLength(200);
            modelBuilder.Entity<Seguro>().Property(x => x.Email).HasMaxLength(30);
            modelBuilder.Entity<Seguro>().Property(x => x.Estado).IsRequired().HasDefaultValue(1);
            #endregion
            #region Tabla CentroRef
            modelBuilder.Entity<CentroRef>().HasKey(x => x.IdCentroRef);
            modelBuilder.Entity<CentroRef>().HasIndex(x => x.NombreCentro).IsUnique();
            modelBuilder.Entity<CentroRef>().Property(x => x.NombreCentro).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<CentroRef>().Property(x => x.Telefono).HasMaxLength(20);
            modelBuilder.Entity<CentroRef>().Property(x => x.Estado).IsRequired().HasDefaultValue(1);
            #endregion
        }
        
    }
}