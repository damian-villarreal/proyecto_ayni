using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;

namespace ayni.Services
{
    public class ComentarioService
    {
        ComentarioRepo comentarioRepo = new ComentarioRepo();

        public void Crear(string texto, int idPublicacion, int idUsuario) {
            Comentario comentario = new Comentario
            {
                Descripcion = texto,
                IdPublicacion = idPublicacion,
                idUsuario = idUsuario
            };
            comentarioRepo.Crear(comentario);
        }

        public List<Comentario> BuscarPorIdPublicacion(int? idPublicacion) {
            return comentarioRepo.BuscarPorIdPublicacion(idPublicacion);
        }
    }


}