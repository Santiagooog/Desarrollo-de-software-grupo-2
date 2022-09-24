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
    public class DetallesDuenosModel : PageModel
    {
        //definiendo variable repo dueño
        private readonly IRepositorioDueno _repoDueno;
        //definiendo variable tipo dueño, objeto de tipo dueño
        //la usamos para meter la info del dueño
        public Dueno dueno {get;set;}
        //este es el metodo constructor de la clase porque se llama igual que la clase.
        public DetallesDuenosModel()
        {
            //esta linea es la misma en el prgram.cs de los metodos. 
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int duenoId)
        {
            dueno = _repoDueno.GetDueno(duenoId);
            if (dueno == null)
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