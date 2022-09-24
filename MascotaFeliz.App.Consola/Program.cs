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
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabajar con las tablas");
                       
            //ListarDuenosFiltro();
            //AddDueno(); //Funcionando
            //BuscarDueno(1); Funcionando
            //AddMascota();//Funcionando
            //ListarMascotas(); Funcionando
            //BuscarMascota(2); Funcionando 
            //ListarVeterinariosFiltro();
            //AddVeterinario();Funcionando
            //BuscarVeterinario(7);
            //ListarVeterinarios();
            //AddHistoria(); Funcionando
            //ListarDuenos(); Funcionando
            //AddVisitaPyP();
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
                Nombre = "Ruffo",
                Color = "Negro", 
                Especie = "Perro",
                Raza = "Criollo"
            };
            _repoMascota.AddMascota(mascota);
        }


         private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Santiago",
                Apellidos = "Lopez", 
                Direccion = "Calle 15",
                Telefono = "3015216594",
                TarjetaProfesional = "TP1872"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void AddHistoria()
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(2002, 05, 10)
                
            };
            _repoHistoria.AddHistoria(historia);
        }


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
            var duenosM = _repoDueno.GetDuenosPorFiltro("J");
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

            private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("A");
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

        private static void AddVisitaPyP()
        {
            var visitasPyP = new VisitaPyP
            {
                Temperatura = 40,
                Peso = 115, 
                FrecuenciaRespiratoria = 150,
                FrecuenciaCardiaca = 150,
                EstadoAnimo = "Enfermo",
                FechaVisita = new DateTime(2002, 07, 16),
                IdVeterinario = 3,
                Recomendaciones = "Dele mas leche ",
                //IdHistoria = 1
            };
            _repoVisitaPyP.AddVisitaPyP(visitasPyP);
        }

        
        
    }
}