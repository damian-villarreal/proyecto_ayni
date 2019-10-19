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

        public bool Postulacion(int? idPublicacion, int? idUsuario) {
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
    }
}