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
                SessionManagement.IdUsuario = usuario.idUsuario;
                SessionManagement.NombreUsuario = usuario.NombreUsuario;
                SessionManagement.Rol = "Rol";
                FormsAuthentication.SetAuthCookie(usuario.NombreUsuario, false);
                var authTicket = new FormsAuthenticationTicket(1, usuario.NombreUsuario, DateTime.Now, DateTime.Now.AddMinutes(20), false, SessionManagement.Rol);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                TempData["Mensaje"] = "<p class='mb-0 text-info'> Se inició sesión correctamente </p>";
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}