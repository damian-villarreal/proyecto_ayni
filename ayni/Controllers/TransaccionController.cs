using ayni.Models;
using ayni.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayni.Controllers
{
    public class TransaccionController : Controller
    {

        TransaccionService transaccionService = new TransaccionService();
        // GET: Transaccion
        public ActionResult Contacto(int? idTransaccion)
        {
            Transaccion t = transaccionService.BuscarPorIdTransaccion(idTransaccion);
            return View(t);
        }

        public ActionResult Calificar(int? idTransaccion) {
            Transaccion t = transaccionService.BuscarPorIdTransaccion(idTransaccion);
            return View(t);
        }

        //[HttpPost]
        //public ActionResult Calificar(Calificacion c) {
        //    transaccionService.Calificar(c);
        //    return View("Index");
        //}
    }
}