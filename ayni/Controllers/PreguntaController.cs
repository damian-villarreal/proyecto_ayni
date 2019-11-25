using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Models;
using ayni.Services;

namespace ayni.Controllers
{
    public class PreguntaController : Controller
    {
        PreguntaService preguntaService = new PreguntaService();
        PublicacionService publicacionService = new PublicacionService();

        [HttpPost]
        public ActionResult Crear()
        {
            var pregunta = Request["Pregunta"];
            int idPublicacion = Convert.ToInt32(Request["idPublicacion"]);
            preguntaService.Crear(pregunta,idPublicacion,Convert.ToInt32(Session["id"]));
            //Publicacion p = publicacionService.BuscarFavorPorIdPublicacion(idPublicacion);
            return RedirectToAction("Detalles","Publicacion", new {@idPublicacion = idPublicacion });
        }

        public ActionResult Enviadas() {
            List<Pregunta> p = preguntaService.BuscarEnviadas(Convert.ToInt32(Session["id"]));
            return View(p);
        }


        public ActionResult Recibidas()
        {
            List<Pregunta> p = preguntaService.BuscarRecibidas(Convert.ToInt32(Session["id"]));
            return View(p);
        }

        public ActionResult Responder(int? idPregunta, string Descripcion) {

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detalle(int? idPregunta) {
            Pregunta p = preguntaService.BuscarPorId(idPregunta);
                return View(p);
        }

        [HttpPost]
        public ActionResult Responder(Pregunta pregunta) {            
            preguntaService.Responder(pregunta.idPregunta, pregunta.Respuesta.Descripcion);
            return RedirectToAction("Recibidas","Pregunta");
        }
    }


}