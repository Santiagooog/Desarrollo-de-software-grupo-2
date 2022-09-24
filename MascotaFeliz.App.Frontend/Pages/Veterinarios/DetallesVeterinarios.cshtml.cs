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
    public class DetallesVeterinariosModel : PageModel
    {
        //definiendo variable repo dueño
        private readonly IRepositorioVeterinario _repoVeterinario;
        //definiendo variable tipo dueño, objeto de tipo dueño
        //la usamos para meter la info del dueño
        public Veterinario veterinario {get;set;}
        //este es el metodo constructor de la clase porque se llama igual que la clase.
        public DetallesVeterinariosModel()
        {
            //esta linea es la misma en el prgram.cs de los metodos. 
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int veterinarioId)
        {
            veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
            if (veterinario == null)
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