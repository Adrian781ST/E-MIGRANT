using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class VerEntidadesModel : PageModel
    {
        private readonly IEntidad _repoEntidad;
        public IEnumerable<Entidad> _ListarEntidades { get; set; }

        public VerEntidadesModel(IEntidad repoEntidad)
        {
            this._repoEntidad = repoEntidad;
        }

        public ActionResult OnGet()
        {
            _ListarEntidades = _repoEntidad.ListarEntidades();
            return Page();
        }
    }
}
