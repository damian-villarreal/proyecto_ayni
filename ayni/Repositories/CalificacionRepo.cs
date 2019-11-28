using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Repositories
{
    public class CalificacionRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        public List<Calificacion> BuscarPorIdTransaccion(int? idTransaccion) {
            return Db.Calificacion.Where(x => x.idTransaccion == idTransaccion).ToList();
        }
    
    }
}