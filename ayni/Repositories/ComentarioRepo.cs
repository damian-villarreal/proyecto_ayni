using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;

namespace ayni.Repositories
{
    public class ComentarioRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        public void Crear(Comentario comentario) {
            Db.Comentario.Add(comentario);
            Db.SaveChanges();
        }

        public List<Comentario> BuscarPorIdPublicacion(int? idPublicacion) {
            return Db.Comentario.Where(x => x.IdPublicacion == idPublicacion).ToList();
        }
    }
}