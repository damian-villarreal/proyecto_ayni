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
                Aceptado = null
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
            return postulacionRepo.ObtenerPorIdPublicacion(idPublicacion);
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

        public List<Postulacion> BuscarPorIdUsuario(int? idUsuario) {
            return postulacionRepo.BuscarPorIdUsuario(idUsuario);
        }

        public Postulacion BuscarAceptadaPorIdPublicacion(int? idPublicacion) {
            return postulacionRepo.BuscarAceptadaPorIdPublicacion(idPublicacion);
        }

        public void Cancelar (int? idPostulacion)
        {
            postulacionRepo.Cancelar(idPostulacion);
        }

        public Postulacion BuscarPorUsuarioYPublicacion(int? idPublicacion, int? idUsuario) {
            return postulacionRepo.BuscarPorUsuarioYPublicacion(idPublicacion, idUsuario);
        }
    }
}