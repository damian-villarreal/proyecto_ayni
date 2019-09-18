using ayni.Models;
using ayni.Services;
using ayni.Sesiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayni.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService usuarioService = new UsuarioService();
        // GET: Usuario
        public ActionResult Registro()
        {
            ViewBag.Message = "Regístrese en esta sección.";

            return View();
        }

        [HttpPost]
        public ActionResult Alta(Usuario usuario)
        {
            //if (ModelState.IsValid)
           // {
                if (usuarioService.Alta(usuario))
                {
                    TempData["RegistroMsj"] = "<p class='mb-0 text-success'> El usuario se registró correctamente </p>";
                }
                else
                {
                    TempData["RegistroMsj"] = "<p class='mb-0 text-danger'> No se pudo registrar el usuario </p>";
                }
           // }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult Modificar(string nombreUsuario)
        {
            var nombreUsuario2 = SessionManagement.NombreUsuario.ToString();
            var usuario = usuarioService.Obtener1(nombreUsuario2);
            ViewData["UsuarioEncontrado"] = usuario;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Modificar(Usuario usuario)
        {
            var usuarioActual = SessionManagement.NombreUsuario.ToString();
            var usuarioModif = usuarioService.Modificar(usuario, usuarioActual);
            //ViewData["UsuarioEncontrado"] = usuario;
            return View();
        }

    }
}