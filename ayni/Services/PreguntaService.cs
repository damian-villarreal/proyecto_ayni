using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Repositories;
using ayni.Models;

namespace ayni.Services
{
    public class PreguntaService
    {
        PreguntaRepo preguntaRepo = new PreguntaRepo();
        RespuestaRepo respuestaRepo = new RespuestaRepo();
        UsuarioService usuarioService = new UsuarioService();

        public void Crear(string texto, int idPublicacion, int idUsuario) {
            Pregunta pregunta = new Pregunta
            {
                Descripcion = texto,
                IdPublicacion = idPublicacion,
                idUsuario = idUsuario,
                Fecha = DateTime.Now
            };
            preguntaRepo.Crear(pregunta);
        }

        public List<Pregunta> BuscarPorIdPublicacion(int? idPublicacion) {
            return preguntaRepo.BuscarPorIdPublicacion(idPublicacion);
        }

        public List<Pregunta> BuscarEnviadas(int? idUsuario) {            
            return preguntaRepo.BuscarEnviadas(idUsuario);
        }

        public List<Pregunta> BuscarRecibidas(int? idUsuario)
        {
            return preguntaRepo.BuscarRecibidas(idUsuario);
        }

        public Pregunta BuscarPorId(int? idPregunta) {
            return preguntaRepo.BuscarPorId(idPregunta);
        }


        public void Responder(int? idPregunta, string Descripcion) {

            ProyectoAyniEntities Db = new ProyectoAyniEntities();

            Pregunta p = Db.Pregunta.Where(x => x.idPregunta == idPregunta).FirstOrDefault();

            Respuesta r = new Respuesta
            {
                Descripcion = Descripcion,
                Fecha = DateTime.Now,
                idUsuario = Sesiones.SessionManagement.IdUsuario,
                Usuario = Db.Usuario.Where(x => x.idUsuario == Sesiones.SessionManagement.IdUsuario).FirstOrDefault()
            };
            Db.Respuesta.Add(r);
            p.idRespuesta = r.idRespuesta;
            Db.SaveChanges();
        }
    }


}