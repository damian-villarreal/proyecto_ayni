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
            Respuesta r = new Respuesta
            {
                idUsuario = Sesiones.SessionManagement.IdUsuario,
                Descripcion = respuesta.Descripcion,
                Fecha = DateTime.Now
            };
            Db.Respuesta.Add(r);
            Db.SaveChanges();
        }
    }
}