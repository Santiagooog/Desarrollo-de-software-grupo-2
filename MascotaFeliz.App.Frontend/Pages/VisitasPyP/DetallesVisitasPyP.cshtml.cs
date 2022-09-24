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
    public class DetallesVisitasPyPModel : PageModel
    {
        //definiendo variable repo dueño
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        //definiendo variable tipo dueño, objeto de tipo dueño
        //la usamos para meter la info del dueño
        public VisitaPyP visitaPyP {get;set;}
        //este es el metodo constructor de la clase porque se llama igual que la clase.
        public DetallesVisitasPyPModel()
        {
            //esta linea es la misma en el prgram.cs de los metodos. 
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int visitaPyPId)
        {
            visitaPyP = _repoVisitaPyP.GetVisitaPyP(visitaPyPId);
            if (visitaPyP == null)
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