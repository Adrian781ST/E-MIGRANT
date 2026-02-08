using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.Entidades
{
    public class EmergenciasModel : PageModel
    {
        private readonly IEmergencia _repoEmergencia;
        [BindProperty]
        public Emergencia _emergencia { get; set; }
        public IEnumerable<Emergencia> _ListarEmergencias { get; set; }

        public EmergenciasModel(IEmergencia repoEmergencia)
        {
            this._repoEmergencia = repoEmergencia;
        }

        public ActionResult OnGet()
        {
            _ListarEmergencias = _repoEmergencia.ListarEmergencias();
            return Page();
        }
    }
}
