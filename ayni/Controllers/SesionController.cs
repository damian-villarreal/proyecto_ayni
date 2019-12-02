using ayni.Models;
using ayni.Services;
using ayni.Sesiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ayni.Controllers
{
    public class SesionController : Controller
    {
        UsuarioService usuarioService = new UsuarioService();
        SesionService sesionService = new SesionService();
        TransaccionService transaccionService = new TransaccionService();
        SaldoService saldoService = new SaldoService();

        // Iniciar: Sesion
        [HttpPost]      
        async
        public Task <ActionResult> Iniciar(Usuario usuario)
        {
            var usuarioResult = sesionService.Iniciar(usuario);
            if (usuarioResult != null)
            {
                Session["id"] = usuarioResult.idUsuario;
                Session["nombreUsuario"] = usuarioResult.NombreUsuario;
                Session["Nombre"] = usuarioResult.Nombre;
                Session["Apellido"] = usuarioResult.Apellido;
                int saldo = await saldoService.GetUserBalance(usuarioService.Obtener1Id(Convert.ToInt32(Session["id"])));
                saldoService.actualizarSaldo(Convert.ToInt32(Session["id"]), saldo);
                Session["saldo"] = saldo;
                Session["PerfilImg"] = usuarioResult.Foto.ToString();
                //SessionManagement.IdUsuario = usuario.idUsuario;
                //SessionManagement.NombreUsuario = usuario.NombreUsuario;
                //SessionManagement.Rol = "Rol";
                //FormsAuthentication.SetAuthCookie(usuario.NombreUsuario, false);
                //var authTicket = new FormsAuthenticationTicket(1, usuario.NombreUsuario, DateTime.Now, DateTime.Now.AddMinutes(20), false, SessionManagement.Rol);
                //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                //var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                //HttpContext.Response.Cookies.Add(authCookie);
                TempData["Mensaje"] = "<div class='d-flex justify-content-center'>" +
                                        "<div class='alert alert-success fixed-top mt-5 float-right col-4'>"+
                                        "<button type='button' class='close' data-dismiss='alert'>&times;</button>" +
                                        "<p class='mb-0 text-success'> Se inició sesión correctamente </p>" +
                                        "</div>"+
                                      "<div>";                
            }
            else
            {
                TempData["Mensaje"] = "<div class='alert alert-danger fixed-top col-4'>" +
                                          "<button type='button' class='close' data-dismiss='alert'>&times;</button>" +
                                          "<p class='mb-0 text-danger'> Nombre de usuario o contraseña incorrectos </p>" +
                                      "<div>";
                TempData["ErrorLogin"] = "Usuario y/o contraseña incorrectos";
                return RedirectToAction("Login", "Home");
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