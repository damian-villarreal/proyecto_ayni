using ayni.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Models;

namespace ayni.Controllers
{
    public class PostulacionController : Controller
    {
        PostulacionService postulacionService = new PostulacionService();
        TransaccionService transaccionService = new TransaccionService();
        // GET: Postulacion
        public ActionResult Postular(int IdPublicacion)
        {
            int idUsuario = Convert.ToInt32(Session["id"]);
            postulacionService.Postulacion(IdPublicacion, idUsuario);
            return RedirectToAction("index", "Home");
        }

        public ActionResult Confirmar(int? idPostulacion) {
            postulacionService.Confirmar(idPostulacion);
            transaccionService.Crear(postulacionService.BuscarPorId(idPostulacion));
            Postulacion p = postulacionService.BuscarPorId(idPostulacion);
            return RedirectToAction("Postulacion", "Publicacion", new { idPublicacion = p.idPublicacion });
        }

        public ActionResult Postulaciones() {
            List<Postulacion> p = postulacionService
                .BuscarPorIdUsuario(Sesiones.SessionManagement.IdUsuario);
            return View(p);
        }
    }
}