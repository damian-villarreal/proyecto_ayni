using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;

namespace ayni.Repositories
{
    public class EstadoPublicacionRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        internal EstadoPublicacion GetByid(int id) {
            return Db.EstadoPublicacion.Where(x => x.idEstadoPublicacion == id).FirstOrDefault();
        }
    }
}