using MercApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MercApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<PropietarioLocal> PropietariosLocales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la entidad Rol
            modelBuilder.Entity<Role>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre)
                    .HasMaxLength(25)
                    .IsRequired();
            });

            // Configurar la entidad Genero
            modelBuilder.Entity<Genero>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre)
                    .HasMaxLength(25)
                    .IsRequired();
            });

            // Configurar la entidad Usuario
            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();
                tb.Property(col => col.Apellido)
                    .HasMaxLength(50)
                    .IsRequired();
                tb.Property(col => col.Email)
                    .HasMaxLength(50)
                    .IsRequired();
                tb.Property(col => col.Pass)
                    .HasMaxLength(50)
                    .IsRequired();
                tb.Property(col => col.Telefono)
                    .HasMaxLength(10);
                tb.Property(col => col.FechaRegistro)
                    .HasColumnType("date");

                // Configurar relaciones con Genero y Rol
                tb.HasOne(col => col.Genero)
                    .WithMany(g => g.Usuarios)
                    .HasForeignKey(col => col.IdGenero)
                    .OnDelete(DeleteBehavior.Restrict);  // Para evitar eliminaciones en cascada

                tb.HasOne(col => col.Roles)
                    .WithMany(r => r.Usuarios)
                    .HasForeignKey(col => col.IdRol)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configurar la entidad Local
            modelBuilder.Entity<Local>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre)
                    .HasMaxLength(150)
                    .IsRequired();
                tb.Property(col => col.Direccion)
                    .HasMaxLength(255)
                    .IsRequired();
                tb.Property(col => col.Telefono)
                    .HasMaxLength(15);
                tb.Property(col => col.FechaCreacion)
                    .HasColumnType("date");

                // Configuración de relación con PropietarioLocal
                tb.HasMany(l => l.PropietariosLocales)
                    .WithOne(pl => pl.Local)
                    .HasForeignKey(pl => pl.LocalId)
                    .OnDelete(DeleteBehavior.Cascade); // Eliminar PropietariosLocales si el Local es eliminado
            });

            // Configurar las relaciones para PropietarioLocal
            modelBuilder.Entity<PropietarioLocal>(tb =>
            {
                tb.HasKey(pl => pl.Id);

                tb.HasOne(pl => pl.Usuario)
                    .WithMany(u => u.PropietariosLocales)
                    .HasForeignKey(pl => pl.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict); // Para evitar eliminaciones en cascada

                tb.HasOne(pl => pl.Local)
                    .WithMany(l => l.PropietariosLocales)
                    .HasForeignKey(pl => pl.LocalId)
                    .OnDelete(DeleteBehavior.Cascade); // Eliminar las relaciones si el Local es eliminado
            });
        }
    }
}
