using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Models;
using ayni.Services;

namespace ayni.Controllers
{
    public class ComentarioController : Controller
    {
        ComentarioService comentarioService = new ComentarioService();
        PublicacionService publicacionService = new PublicacionService();

        [HttpPost]
        public ActionResult Crear()
        {
            var comentario = Request["Comentario"];
            int idPublicacion = Convert.ToInt32(Request["idPublicacion"]);
            comentarioService.Crear(comentario,idPublicacion,Convert.ToInt32(Session["id"]));
            //Publicacion p = publicacionService.BuscarFavorPorIdPublicacion(idPublicacion);
            return RedirectToAction("Detalles","Publicacion", new {@idPublicacion = idPublicacion });
        }
    }
}