using ayni.Models;
using ayni.Services;
using ayni.Sesiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ayni.Controllers
{
    public class SesionController : Controller
    {
        SesionService sesionService = new SesionService();

        // Iniciar: Sesion
        [HttpPost]
        public ActionResult Iniciar(Usuario usuario)
        {

            var usuarioResult = sesionService.Iniciar(usuario);
            if (usuarioResult != null)
            {
                Session["id"] = usuarioResult.idUsuario;
                Session["nombreUsuario"] = usuarioResult.NombreUsuario;
                //SessionManagement.IdUsuario = usuario.idUsuario;
                //SessionManagement.NombreUsuario = usuario.NombreUsuario;
                //SessionManagement.Rol = "Rol";
                //FormsAuthentication.SetAuthCookie(usuario.NombreUsuario, false);
                //var authTicket = new FormsAuthenticationTicket(1, usuario.NombreUsuario, DateTime.Now, DateTime.Now.AddMinutes(20), false, SessionManagement.Rol);
                //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                //var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                //HttpContext.Response.Cookies.Add(authCookie);
                TempData["Mensaje"] = "<div class='alert alert-success fixed-top'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-success'> Se inició sesión correctamente </p><div>";
            }
            else
            {
                TempData["Mensaje"] = "<div class='alert alert-danger fixed-top'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-danger'> Nombre de usuario o contraseña incorrectos </p><div>";
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}