using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;
using System.Data.Entity;
using ayni.Services;

namespace ayni.Repositories
{
    public class PreguntaRepo
    {
        ProyectoAyniEntities Db = new ProyectoAyniEntities();

        public void Crear(Pregunta pregunta) {
            Db.Pregunta.Add(pregunta);
            Db.SaveChanges();
        }

        public List<Pregunta> BuscarPorIdPublicacion(int? idPublicacion) {
            return Db.Pregunta.
                Where(x => x.IdPublicacion == idPublicacion).
                OrderByDescending(x => x.Fecha).
                ToList();
        }

        public List<Pregunta> BuscarEnviadas(int? idUsuario) {
            List<Pregunta> preguntas = Db.Pregunta
                .OrderByDescending(x => x.Fecha)
                .Include(x => x.Respuesta)
                .Where(x => x.idUsuario == idUsuario).ToList();
            return preguntas;
        }

        public List<Pregunta> BuscarRecibidas(int? idUsuario)
        {
            return Db.Pregunta
                .OrderByDescending(x => x.Fecha)
                                .Include(x => x.Respuesta)
                .Where(x => x.Publicacion.idUsuario == idUsuario).ToList();
        }

        public Pregunta BuscarPorId(int? IdPregunta) {
            return Db.Pregunta.Where(x => x.idPregunta == IdPregunta).FirstOrDefault();
        }

        public void GuardarCambios() {
            Db.SaveChanges();
        }

    }
}