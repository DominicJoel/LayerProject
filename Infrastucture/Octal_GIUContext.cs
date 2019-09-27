using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApIGius.Models;

namespace Infrastucture.Models
{
    public partial class Octal_GIUContext : DbContext
    {
        public Octal_GIUContext()
        {
        }

        public Octal_GIUContext(DbContextOptions<Octal_GIUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreasList> AreasList { get; set; }
        public virtual DbSet<MunicipiosList> MunicipiosList { get; set; }
        public virtual DbSet<SectoresParajesList> SectoresParajesList { get; set; }
        public virtual DbSet<SitiosEstadosList> SitiosEstadosList { get; set; }
        public virtual DbSet<SitiosMain> SitiosMain { get; set; }
        public virtual DbSet<SitiosTiposList> SitiosTiposList { get; set; }
        public virtual DbSet<UnidadesEstadosList> UnidadesEstadosList { get; set; }
        public virtual DbSet<UnidadesMain> UnidadesMain { get; set; }
        public virtual DbSet<UnidadesTiposList> UnidadesTiposList { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //       #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreasList>(entity =>
            {
                entity.HasKey(e => e.AreaNumero);

                entity.ToTable("Areas_List");

                entity.Property(e => e.AreaNumero).HasColumnName("Area_Numero");

                entity.Property(e => e.AreaClienteId)
                    .IsRequired()
                    .HasColumnName("Area_Cliente_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AreaLatitud)
                    .HasColumnName("Area_Latitud")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.AreaLongitud)
                    .HasColumnName("Area_Longitud")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.AreaNombre)
                    .IsRequired()
                    .HasColumnName("Area_Nombre")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.AreaObjetivo)
                    .IsRequired()
                    .HasColumnName("Area_Objetivo")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AreaUnidades)
                    .IsRequired()
                    .HasColumnName("Area_Unidades")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIp)
                    .IsRequired()
                    .HasColumnName("Seguridad_IP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SitioNumero).HasColumnName("Sitio_Numero");

                entity.HasOne(d => d.SitioNumeroNavigation)
                    .WithMany(p => p.AreasList)
                    .HasForeignKey(d => d.SitioNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_List_Sitios_Main");
            });

            modelBuilder.Entity<MunicipiosList>(entity =>
            {
                entity.HasKey(e => e.MunicipioNumero);

                entity.ToTable("Municipios_List");

                entity.Property(e => e.MunicipioNumero)
                    .HasColumnName("Municipio_Numero")
                    .ValueGeneratedNever();

                entity.Property(e => e.MunicipioNombre)
                    .IsRequired()
                    .HasColumnName("Municipio_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MunicipioProvinciaNombre)
                    .IsRequired()
                    .HasColumnName("Municipio_Provincia_Nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinciaNombre)
                    .IsRequired()
                    .HasColumnName("Provincia_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinciaNumero).HasColumnName("Provincia_Numero");

                entity.Property(e => e.RegionGeograficaNumero).HasColumnName("Region_Geografica_Numero");

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIpc)
                    .IsRequired()
                    .HasColumnName("Seguridad_IPC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SectoresParajesList>(entity =>
            {
                entity.HasKey(e => e.SectorSecuencia);

                entity.ToTable("Sectores_Parajes_List");

                entity.Property(e => e.SectorSecuencia).HasColumnName("Sector_Secuencia");

                entity.Property(e => e.CiudadNumero).HasColumnName("Ciudad_Numero");

                entity.Property(e => e.MunicipioNumero).HasColumnName("Municipio_Numero");

                entity.Property(e => e.SectorNombre)
                    .IsRequired()
                    .HasColumnName("Sector_Nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SectorNumero).HasColumnName("Sector_Numero");

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadIp)
                    .IsRequired()
                    .HasColumnName("Seguridad_IP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SitiosEstadosList>(entity =>
            {
                entity.HasKey(e => e.EstadoNumero);

                entity.ToTable("Sitios_Estados_List");

                entity.Property(e => e.EstadoNumero).HasColumnName("Estado_Numero");

                entity.Property(e => e.EstadoCodigo)
                    .IsRequired()
                    .HasColumnName("Estado_Codigo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCriterio)
                    .IsRequired()
                    .HasColumnName("Estado_Criterio")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoDespcricion)
                    .IsRequired()
                    .HasColumnName("Estado_Despcricion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoExplicacion)
                    .IsRequired()
                    .HasColumnName("Estado_Explicacion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoListar)
                    .IsRequired()
                    .HasColumnName("Estado_Listar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoPublicar)
                    .IsRequired()
                    .HasColumnName("Estado_Publicar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIpc)
                    .IsRequired()
                    .HasColumnName("Seguridad_IPC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SitiosMain>(entity =>
            {
                entity.HasKey(e => e.SitioNumero);

                entity.ToTable("Sitios_Main");

                entity.Property(e => e.SitioNumero).HasColumnName("Sitio_Numero");

                entity.Property(e => e.EstadoNumero).HasColumnName("Estado_Numero");

                entity.Property(e => e.MunicipioDireccionNumero).HasColumnName("Municipio_Direccion_Numero");

                entity.Property(e => e.SectorSecuencia).HasColumnName("Sector_Secuencia");

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIp)
                    .IsRequired()
                    .HasColumnName("Seguridad_IP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SitioClienteId)
                    .IsRequired()
                    .HasColumnName("Sitio_Cliente_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SitioDescripcion)
                    .IsRequired()
                    .HasColumnName("Sitio_Descripcion")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.SitioDireccion)
                    .IsRequired()
                    .HasColumnName("Sitio_Direccion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SitioDireccionLatitud)
                    .HasColumnName("Sitio_Direccion_Latitud")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SitioDireccionLongitud)
                    .HasColumnName("Sitio_Direccion_Longitud")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SitioDireccionProximo)
                    .IsRequired()
                    .HasColumnName("Sitio_Direccion_Proximo")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SitioNombre)
                    .IsRequired()
                    .HasColumnName("Sitio_Nombre")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SitioTelefonoDos)
                    .IsRequired()
                    .HasColumnName("Sitio_Telefono_Dos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SitioTelefonoUno)
                    .IsRequired()
                    .HasColumnName("Sitio_Telefono_Uno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoNumero).HasColumnName("Tipo_Numero");

                entity.HasOne(d => d.EstadoNumeroNavigation)
                    .WithMany(p => p.SitiosMain)
                    .HasForeignKey(d => d.EstadoNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sitios_Main_Sitios_Estatus_List");

                entity.HasOne(d => d.MunicipioDireccionNumeroNavigation)
                    .WithMany(p => p.SitiosMain)
                    .HasForeignKey(d => d.MunicipioDireccionNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sitios_Main_Municipios_List");

                entity.HasOne(d => d.SectorSecuenciaNavigation)
                    .WithMany(p => p.SitiosMain)
                    .HasForeignKey(d => d.SectorSecuencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sitios_Main_Sectores_Parajes_List");

                entity.HasOne(d => d.TipoNumeroNavigation)
                    .WithMany(p => p.SitiosMain)
                    .HasForeignKey(d => d.TipoNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sitios_Main_Sitios_Tipos_List");
            });

            modelBuilder.Entity<SitiosTiposList>(entity =>
            {
                entity.HasKey(e => e.TipoNumero);

                entity.ToTable("Sitios_Tipos_List");

                entity.Property(e => e.TipoNumero).HasColumnName("Tipo_Numero");

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIpc)
                    .IsRequired()
                    .HasColumnName("Seguridad_IPC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCriterio)
                    .IsRequired()
                    .HasColumnName("Tipo_Criterio")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDespcricion)
                    .IsRequired()
                    .HasColumnName("Tipo_Despcricion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoExplicacion)
                    .IsRequired()
                    .HasColumnName("Tipo_Explicacion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TipoListar)
                    .IsRequired()
                    .HasColumnName("Tipo_Listar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPrefijo)
                    .IsRequired()
                    .HasColumnName("Tipo_Prefijo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPublicar)
                    .IsRequired()
                    .HasColumnName("Tipo_Publicar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUnidad)
                    .IsRequired()
                    .HasColumnName("Tipo_Unidad")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnidadesEstadosList>(entity =>
            {
                entity.HasKey(e => e.EstatoNumero);

                entity.ToTable("Unidades_Estados_List");

                entity.Property(e => e.EstatoNumero)
                    .HasColumnName("Estato_Numero")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EstatoClienteId)
                    .IsRequired()
                    .HasColumnName("Estato_Cliente_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstatoCuotas)
                    .IsRequired()
                    .HasColumnName("Estato_Cuotas")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstatoDespcricion)
                    .IsRequired()
                    .HasColumnName("Estato_Despcricion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstatoPublicar)
                    .IsRequired()
                    .HasColumnName("Estato_Publicar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIpc)
                    .IsRequired()
                    .HasColumnName("Seguridad_IPC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnidadesMain>(entity =>
            {
                entity.HasKey(e => e.UnidadNumero);

                entity.ToTable("Unidades_Main");

                entity.Property(e => e.UnidadNumero).HasColumnName("Unidad_Numero");

                entity.Property(e => e.AreaNumero).HasColumnName("Area_Numero");

                entity.Property(e => e.EstatoNumero).HasColumnName("Estato_Numero");

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIpc)
                    .IsRequired()
                    .HasColumnName("Seguridad_IPC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SitioNumero).HasColumnName("Sitio_Numero");

                entity.Property(e => e.UnidadClienteId)
                    .IsRequired()
                    .HasColumnName("Unidad_Cliente_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadTipoNumero).HasColumnName("Unidad_Tipo_Numero");

                entity.HasOne(d => d.EstatoNumeroNavigation)
                    .WithMany(p => p.UnidadesMain)
                    .HasForeignKey(d => d.EstatoNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidades_Main_Unidades_Estatus_List");

                entity.HasOne(d => d.UnidadTipoNumeroNavigation)
                    .WithMany(p => p.UnidadesMain)
                    .HasForeignKey(d => d.UnidadTipoNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidades_Main_Unidades_Tipos_List");
            });

            modelBuilder.Entity<UnidadesTiposList>(entity =>
            {
                entity.HasKey(e => e.UnidadTipoNumero);

                entity.ToTable("Unidades_Tipos_List");

                entity.Property(e => e.UnidadTipoNumero).HasColumnName("Unidad_Tipo_Numero");

                entity.Property(e => e.SeguridadCuando)
                    .HasColumnName("Seguridad_Cuando")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SeguridadEstado)
                    .IsRequired()
                    .HasColumnName("Seguridad_Estado")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.SeguridadIpc)
                    .IsRequired()
                    .HasColumnName("Seguridad_IPC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SeguridadQuien)
                    .IsRequired()
                    .HasColumnName("Seguridad_Quien")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadExplicacion)
                    .IsRequired()
                    .HasColumnName("Unidad_Explicacion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadListar)
                    .IsRequired()
                    .HasColumnName("Unidad_Listar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadPrefijo)
                    .IsRequired()
                    .HasColumnName("Unidad_Prefijo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadPublicar)
                    .IsRequired()
                    .HasColumnName("Unidad_Publicar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadTipoDescripcion)
                    .IsRequired()
                    .HasColumnName("Unidad_Tipo_Descripcion")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadTipoHeredar)
                    .IsRequired()
                    .HasColumnName("Unidad_Tipo_Heredar")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }
    }
}
