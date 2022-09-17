using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;


namespace MascotaFeliz.App.Consola
{
    class Program
    {

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        //private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        //private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabajar con las tablas");
                       
            //ListarDuenosFiltro();
            //AddDueno();
            //BuscarDueno(5);
            //AddMascota();
            //ListarMascotas(); 
            //BuscarMascota(2);
            //ListarVeterinariosFiltro();
            //AddVeterinario();
            //BuscarVeterinario(7);
            ListarVeterinarios();
            //AddHistoria();
            //ListarDuenos();

        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Juan",
                Apellidos = "Martinez", 
                Direccion = "Carrera 12a",
                Telefono = "3201679452",
                Correo = "martinezjuan@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }
        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "loki",
                Color = "negro", 
                Especie = "Perro",
                Raza = "crillo"
            };
            _repoMascota.AddMascota(mascota);
        }


         private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Jesus",
                Apellidos = "Juarez", 
                Direccion = "Calle 65",
                Telefono = "3013216547",
                TarjetaProfesional = "TP1987"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

       /* private static void AddHistoria()
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(1990, 04, 12)
                
            };
            _repoHistoria.AddHistoria(historia);
        }*/


        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos+" "+dueno.Direccion+" "+dueno.Telefono+" "+dueno.Correo);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }
        //buscar una mascota
        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Especie+" "+mascota.Color+" "+mascota.Raza+" ");
        }
        //Retorna Lista De Mascotas
            private static void ListarMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascotas)
            {
                Console.WriteLine(m.Nombre +" "+ m.Especie+" "+ m.Color+" "+ m.Raza);
            }

        }

            private static void ListarVeterinarios()
        {
            var veterinarios = _repoVeterinario.GetAllVeterinarios();
            foreach (Veterinario s in veterinarios)
            {
                Console.WriteLine("hola mundo");
                Console.WriteLine(s.Nombres +""+ s.Apellidos);
                
            }

        }

            


            private static void ListarDuenosFiltro()
        {
            var duenosM = _repoDueno.GetDuenosPorFiltro("Liliana");
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

            private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("e");
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

            private static void ListarDuenos()
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
            {
                Console.WriteLine(d.Nombres +" "+ d.Apellidos);
            }

        }

        
        
    }
}