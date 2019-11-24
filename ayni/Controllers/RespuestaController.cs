using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Models;

namespace ayni.Controllers
{
    public class RespuestaController : Controller
    {
        [HttpPost]
        public ActionResult Crear(Respuesta respuesta, int? idPregunta)
        {
            Respuesta r = new Respuesta();
            
            return View();
        }
    }
}