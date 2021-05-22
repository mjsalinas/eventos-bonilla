using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventosBonilla.EventosBonilla.Dominio.Modelos
{
    public partial class eventos_bonillaContext : DbContext
    {
        public eventos_bonillaContext()
        {
        }

        public eventos_bonillaContext(DbContextOptions<eventos_bonillaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Mobiliario> Mobiliario { get; set; }
        public virtual DbSet<MobiliarioPorReservacion> MobiliarioPorReservacion { get; set; }
        public virtual DbSet<Reservacion> Reservacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=eventos_bonilla", x => x.ServerVersion("5.7.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdClientes)
                    .HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.Property(e => e.IdClientes)
                    .HasColumnName("id_clientes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoTelefono)
                    .HasColumnName("no_telefono")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PRIMARY");

                entity.ToTable("eventos");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("id_categoria_idx");

                entity.Property(e => e.IdEvento)
                    .HasColumnName("id_evento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Responsable)
                    .HasColumnName("responsable")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Mobiliario>(entity =>
            {
                entity.HasKey(e => e.IdMobiliario)
                    .HasName("PRIMARY");

                entity.ToTable("mobiliario");

                entity.Property(e => e.IdMobiliario)
                    .HasColumnName("id_mobiliario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<MobiliarioPorReservacion>(entity =>
            {
                entity.HasKey(e => e.IdMobiliarioPorReservacion)
                    .HasName("PRIMARY");

                entity.ToTable("mobiliario_por_reservacion");

                entity.HasIndex(e => e.IdMobiliario)
                    .HasName("id_mobiliario_idx");

                entity.HasIndex(e => e.IdReservacion)
                    .HasName("id_reservacion_idx");

                entity.Property(e => e.IdMobiliarioPorReservacion)
                    .HasColumnName("id_mobiliario_por_reservacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMobiliario)
                    .HasColumnName("id_mobiliario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdReservacion)
                    .HasColumnName("id_reservacion")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PRIMARY");

                entity.ToTable("reservacion");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.HasIndex(e => e.IdEvento)
                    .HasName("id_evento_idx");

                entity.Property(e => e.IdReservacion)
                    .HasColumnName("id_reservacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriaEvento)
                    .HasColumnName("categoria_evento")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FechaReservacion)
                    .HasColumnName("fecha_reservacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEvento)
                    .HasColumnName("id_evento")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
