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
    public class AtenderEmergenciaModel : PageModel
    {
        public readonly IEmergencia _repoEmergencia;
        [BindProperty]
        public Emergencia _emergencia { get; set; }
        public AtenderEmergenciaModel(IEmergencia repoEmergencia)
        {
            this._repoEmergencia = repoEmergencia;
        }
        public ActionResult OnGet(int emeId)
        {
            _emergencia = _repoEmergencia.ReadByIdOnly(emeId);
            if (_emergencia is null)
            {
                ViewData["Existe"] = "La emergencia no existe por favor validar";
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            var emergenciaExistente = _repoEmergencia.ReadByIdOnly(_emergencia.Id);
            if (emergenciaExistente is null)
            {
                ViewData["Existe"] = "La emergencia no existe por favor validar";
            }
            else if (emergenciaExistente.Status != "PENDIENTE")
            {
                ViewData["Mensaje"] = "El estado de la emergencia no puede modificarse";
                _emergencia = emergenciaExistente;
            }
            else
            {
                bool _actualizado = _repoEmergencia.UpdateStatus(_emergencia.Id, "ATENDIDA");
                if (_actualizado)
                {
                    // Redirect to Emergencias page instead of showing modal
                    return RedirectToPage("Emergencias");
                }
                else
                {
                    ViewData["Mensaje"] = "Hubo un problema al actualizar";
                    _emergencia = emergenciaExistente;
                }
            }
            return Page();
        }
    }
}
