using System;
namespace MascotaFeliz.App.Dominio
{
    public class Mascota
    {
       public int Id {get;set;}
       public string Nombre {get;set;}
       public string Color {get;set;}
       public string Especie {get;set;}
       public string Raza {get;set;}
       ///relacion de asociasion
       ///Relacion de mascota y dueno
       public Dueno Dueno {get;set;}
       ///Relacion de mascota y veterinario
       public Veterinario Veterinario {get;set;}
       ///Relacion de mascoya y historia
       public Historia Historia {get;set;}
    }



}