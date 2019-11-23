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
    }


}