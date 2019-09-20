using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;


namespace ayni.Repositories
{
    public class TipoPublicacionRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        internal List<TipoPublicacion> List()
        {
            return Db.TipoPublicacion.ToList();
        }

        internal TipoPublicacion GetById(int? id)
        {
            return Db.TipoPublicacion.Where(x => x.idTipoPublicacion == id).FirstOrDefault();
        }
    }
}