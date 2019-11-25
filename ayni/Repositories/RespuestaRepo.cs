using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Repositories
{
    public class RespuestaRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        public void Crear(Respuesta respuesta) {           
            Db.Respuesta.Add(respuesta);
            Db.SaveChanges();
        }
    }
}