﻿using ayni.Models;
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
            Calificacion c = transaccionService.buscarTransaccionYaCalificada(idTransaccion);
            if (c == null)
            {
                ViewBag.TransaccionCalificada = "falso";
            }
            else {
                ViewBag.TransaccionCalificada = "verdadero";
            }
            Transaccion t = transaccionService.BuscarPorIdTransaccion(idTransaccion);
            return View(t);
        }

        public ActionResult Calificar(int? idTransaccion) {
            Transaccion t = transaccionService.BuscarPorIdTransaccion(idTransaccion);
            return View(t);
        }

        [HttpPost]
        public ActionResult Calificar() {

            Calificacion calificacion = new Calificacion
            {
                Puntaje = Convert.ToInt32(Request["stars"]),
                ComentarioCalificacion = Request["comentario"],
                idTransaccion = Convert.ToInt32(Request["idTransaccion"]),
                idUsuarioCalificado = Convert.ToInt32(Request["idUsuarioCalificado"]),
                idUsuarioCalifica = Sesiones.SessionManagement.IdUsuario,
            };

            Transaccion t = transaccionService.BuscarPorIdTransaccion(calificacion.idTransaccion);

            //si el usuario que ofrece es el mismo que el usuario logueado, califica al que recibe
            if (t.idUsuarioOfrece == Sesiones.SessionManagement.IdUsuario)
            {
                calificacion.idTipoCalificacion = 1;
            }

            if (t.idUsuarioRecibe == Sesiones.SessionManagement.IdUsuario)
            {
                calificacion.idTipoCalificacion = 2;
            }

            transaccionService.Calificar(calificacion);
            return RedirectToAction("Index", "Home");
        }
    }
}
