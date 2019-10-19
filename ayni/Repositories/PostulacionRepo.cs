using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Repositories
{
    public class PostulacionRepo
    {
        public ProyectoAyniEntities Db = new ProyectoAyniEntities();
        
        public Boolean Crear(Postulacion postulacion) {
            //solo crea una postulacion si no fue creada antes
            Postulacion postulacionBuscada = Db.Postulacion.Where(p => p.idPublicacion == postulacion.idPublicacion
            && p.idPostulante == postulacion.idPostulante).FirstOrDefault();
            if (postulacionBuscada == null)
            {
                Db.Postulacion.Add(postulacion);
                Db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}