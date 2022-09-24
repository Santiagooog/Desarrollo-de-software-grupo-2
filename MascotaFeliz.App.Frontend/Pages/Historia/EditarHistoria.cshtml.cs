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
    public class EditarHistoriasModel : PageModel
    {

        private readonly IRepositorioHistoria _repoHistoria;
        [BindProperty]
        public Historia historia {get;set;}

        public EditarHistoriasModel()
        {
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? historiaId){

            if(historiaId.HasValue)
            {
                historia = _repoHistoria.GetHistoria(historiaId.Value);
            }
            else
            {
                historia = new Dueno();
            }
            if(historia == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
            

        public IActionResult OnPost()
        {

            if(!ModelState.IsValid)
            {

                return Page();
            }
            if(historia.Id > 0)
            {
                historia = _repoHistoria.UpdateHistoria(historia);
            }
            else
            {
                _repoHistoria.AddHistoria(historia);
            }
            return Page();
        }

    }
}
