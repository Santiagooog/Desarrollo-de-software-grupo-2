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
    public class ListaVisitasPyPModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        public IEnumerable<VisitaPyP> ListaVisitasPyP {get;set;} 

        public ListaVisitasPyPModel(){
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        }

        public void OnGet()
        {
            ListaVisitasPyP = _repoVisitaPyP.GetAllVisitasPyP();
        }
    }
}