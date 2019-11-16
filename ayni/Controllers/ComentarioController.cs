using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Services;

namespace ayni.Controllers
{
    public class ComentarioController : Controller
    {
        ComentarioService comentarioService = new ComentarioService();

        [HttpPost]
        public ActionResult Crear()
        {
            var comentario = Request["Comentario"];
            var idPublicacion = Convert.ToInt32(Request["idPublicacion"]);
            comentarioService.Crear(comentario,idPublicacion,Convert.ToInt32(Session["id"]));
            return RedirectToAction("Detalles", "Publicacion", idPublicacion);
        }
    }
}