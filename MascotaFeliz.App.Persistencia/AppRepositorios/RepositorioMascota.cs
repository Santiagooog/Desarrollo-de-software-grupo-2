using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }
        //metodo para adicionar mascota
        public Mascota AddMascota(Mascota mascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }
        //metodo para eliminar mascota, primero la buscamos y despues la eliminamos.
        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }
        //nos retorna una lista con todas las mascotas
       public IEnumerable<Mascota> GetAllMascotas()
        {
            return GetAllMascotas_();
        }
        //retornar una mascota por filtro
        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro)
        {
            var mascotas = GetAllMascotas(); // Obtiene todos los saludos
            if (mascotas != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return mascotas;
        }
        //retorna todas las mascotas...
        public IEnumerable<Mascota> GetAllMascotas_()
        {
            return _appContext.Mascotas;
        }
        //retorna una mascota dada su identificacion
        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
        }
        //Metodo para actualizar mascota, primero la buscamos con el id y luego la actualizamos
        public Mascota UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(m => m.Id == mascota.Id);
            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.Nombre = mascota.Nombre;
                mascotaEncontrada.Color = mascota.Color;
                mascotaEncontrada.Especie = mascota.Especie;
                mascotaEncontrada.Raza = mascota.Raza;
                _appContext.SaveChanges();
            }
            return mascotaEncontrada;
        }     
    }
}
