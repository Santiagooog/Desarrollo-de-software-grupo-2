///Importar el ef de microsoft que vamos a usar
using Microsoft.EntityFrameworkCore;
///importamos un puente para que pueda hacer las tablas apartir de las clases
using MascotaFeliz.App.Dominio;
///.persistencias porque estamos en esa capa
namespace MascotaFeliz.App.Persistencia
{
    ///AppContext hereda de la clase DbContext que sale del import del EF
    public class AppContext : DbContext
    {
        ///DbSet para que cada una de las clases sean una tabla.
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Veterinario> Veterinarios {get;set;}
        public DbSet<Dueno> Duenos {get;set;}
        public DbSet<VisitaPyP> VisitasPyP {get;set;}
        public DbSet<Historia> Historias {get;set;}
        public DbSet<Mascota> Mascotas {get;set;}

        ///este es el metodo que configura la cadena de conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MascotaFelizData");
            }
        }
    }
}