using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;
using ayni.Repositories;


namespace ayni.Services
{

    public class PostulacionService
    {
        PostulacionRepo postulacionRepo = new PostulacionRepo();
        PublicacionService publicacionService = new PublicacionService();

        public bool Postulacion(int idPublicacion, int idUsuario) {
            Postulacion postulacion = new Postulacion
            {
                idPostulante = idUsuario,
                idPublicacion = idPublicacion,
                fecha = DateTime.Today,
                Aceptado = false
            };
            if (postulacionRepo.Crear(postulacion))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public List<Postulacion> ObtenerPorIdPublicacion(int? idPublicacion) {
            return postulacionRepo.obtenerPorIdPublicacion(idPublicacion);
        }

        public Boolean Confirmar(int? idPostulacion) {
            postulacionRepo.Confirmar(idPostulacion);
            Postulacion pos = postulacionRepo.BuscarporId(idPostulacion);
            Publicacion p = publicacionService.BuscarPorID(pos.idPublicacion);
            p.idEstadoPublicacion = 2;
            publicacionService.Modificar(p);
            return true;
        }

        public Postulacion BuscarPorId(int? idPostulacion) {
            return postulacionRepo.BuscarporId(idPostulacion);
        }
    }
}