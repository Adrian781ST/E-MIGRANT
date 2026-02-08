using Dominio;
using System.Collections.Generic;

namespace  Persistencia
{
    public interface IRepositorioCalificacionApp{
        
        CalificacionApp  AddCalificacionApp (CalificacionApp calificacionApp );
        IEnumerable<CalificacionApp> ListarCalificaciones();
    }
}