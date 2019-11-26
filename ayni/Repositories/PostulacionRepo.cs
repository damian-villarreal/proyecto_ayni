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

        public List<Postulacion> ObtenerPorIdPublicacion(int? idPublicacion) {
            return Db.Postulacion.Where(x => x.idPublicacion == idPublicacion).ToList();
        }

        public Boolean Confirmar(int? idPostulacion)
        {
            Postulacion p = Db.Postulacion.Where(x => x.idPostulacion == idPostulacion).FirstOrDefault();
            p.Aceptado = true;
            Db.SaveChanges();
            return true;
        }

        public Postulacion BuscarporId(int? idPostulacion)
        {
            return Db.Postulacion.Where(x => x.idPostulacion == idPostulacion).FirstOrDefault();
        }

        public List<Postulacion> ListarPostulacionesParaUnUsuario(int? idUsuario) {
            return Db.Postulacion.Where(x => x.Publicacion.idUsuario == idUsuario).ToList();
        }

        public List<Postulacion> BuscarPorIdUsuario(int? idUsuario) {
            return Db.Postulacion.Where(x => x.idPostulante == idUsuario).ToList();
        }

        public Postulacion BuscarAceptadaPorIdPublicacion(int? idPublicacion) {
            return Db.Postulacion.Where(x => x.idPublicacion == idPublicacion && x.Aceptado == true).FirstOrDefault();
        }
    }
}