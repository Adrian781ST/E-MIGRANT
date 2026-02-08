using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{

    public enum ValorCalificacion{

        [Display(Name = "Excelente")]
        Excelente,
        [Display(Name = "Muy bueno")]
        MuyBueno,
        [Display(Name = "Bueno")]
        Bueno,
        [Display(Name = "Regular")]
        Regular,
        [Display(Name = "Malo")]
        Malo
    }
    public class CalificacionApp{

        public int Id{get;set;}

        public ValorCalificacion ValorCalificacion{get;set;}
        public int numeroDocumentoMigrante {get;set;}
        public DateTime Fecha {get;set;}

    }

}
