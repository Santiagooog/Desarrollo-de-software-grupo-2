using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetallesMascotasModel : PageModel
    {
        //definiendo variable repo dueño
        private readonly IRepositorioMascota _repoMascota;
        //definiendo variable tipo dueño, objeto de tipo dueño
        //la usamos para meter la info del dueño
        public Mascota mascota {get;set;}
        //este es el metodo constructor de la clase porque se llama igual que la clase.
        public DetallesMascotasModel()
        {
            //esta linea es la misma en el prgram.cs de los metodos. 
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int mascotaId)
        {
            mascota = _repoMascota.GetMascota(mascotaId);
            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}