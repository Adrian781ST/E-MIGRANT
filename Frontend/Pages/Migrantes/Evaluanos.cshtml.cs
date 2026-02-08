using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;

namespace Frontend
{
    public class EvaluanosModel : PageModel
    {
        private readonly IRepositorioCalificacionApp _repoCalificacion;
        public CalificacionApp CalificacionApp { get; set; }
        public bool Submitted { get; set; }
        
        public EvaluanosModel(IRepositorioCalificacionApp repoCalificacion)
        {
            this._repoCalificacion = repoCalificacion;
        }

        public void OnGet()
        {
            CalificacionApp = new CalificacionApp();
            Submitted = false;
        }

        public IActionResult OnPost(CalificacionApp calificacionApp)
        {
            calificacionApp.Fecha = DateTime.Now;
            _repoCalificacion.AddCalificacionApp(calificacionApp);
            Submitted = true;
            CalificacionApp = new CalificacionApp();
            return Page();
        }
    }
}
