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

<<<<<<< HEAD
        [HttpPost]
        public ActionResult Calificar() {
            Calificacion calificacion = new Calificacion
            {
                Puntaje = Convert.ToInt32(Request["stars"]),
                ComentarioCalificacion = Request["comentario"],
                idTransaccion = Convert.ToInt32(Request["idTransaccion"]),
                idUsuarioCalificado = Convert.ToInt32(Request["idUsuarioCalificado"]),
            };
            transaccionService.Calificar(calificacion);
            return View("Index");
        }
=======
        //[HttpPost]
        //public ActionResult Calificar(Calificacion c) {
        //    transaccionService.Calificar(c);
        //    return View("Index");
        //}
>>>>>>> a3d26366671c4a438caf457737cc3e22ebeb21a6
    }
}