using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages.Gerencia
{
    public class EvaluacionesAdminModel : PageModel
    {
        private readonly IRepositorioCalificacionApp _repoCalificacion;
        public IEnumerable<CalificacionApp> _ListarCalificaciones { get; set; }

        public EvaluacionesAdminModel(IRepositorioCalificacionApp repoCalificacion)
        {
            this._repoCalificacion = repoCalificacion;
        }

        public ActionResult OnGet()
        {
            _ListarCalificaciones = _repoCalificacion.ListarCalificaciones();
            return Page();
        }
    }
}
