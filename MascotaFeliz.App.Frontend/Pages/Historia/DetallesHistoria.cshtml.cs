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
    public class DetallesHistoriasModel : PageModel
    {
        //definiendo variable repo dueño
        private readonly IRepositorioHistoria _repoHistoria;
        //definiendo variable tipo dueño, objeto de tipo dueño
        //la usamos para meter la info del dueño
        public Historia hisotira {get;set;}
        //este es el metodo constructor de la clase porque se llama igual que la clase.
        public DetallesHistoriasModel()
        {
            //esta linea es la misma en el prgram.cs de los metodos. 
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int historiaId)
        {
            hisotira = _repoHistoria.GetHistoria(historiaId);
            if (historia == null)
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