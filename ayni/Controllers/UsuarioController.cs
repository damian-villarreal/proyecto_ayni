using ayni.Models;
using ayni.Services;
using ayni.Sesiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ayni.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService usuarioService = new UsuarioService();
        SesionService sesionService = new SesionService();
        ProyectoAyniEntities ctx = new ProyectoAyniEntities();

        // GET: Usuario
        public ActionResult Registro()
        {
            ViewBag.Message = "Regístrese en esta sección.";

            return View();
        }

        [HttpPost]
        async public Task<ActionResult> Alta(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                var usuarioExistente = usuarioService.Obtener1(usuario.NombreUsuario);
                if(usuarioExistente == null)
                {
                    if (await usuarioService.Alta(usuario))
                    {
                        TempData["RegistroMsj"] = "<p class='mb-0 text-success'> El usuario se registró correctamente </p>";
                    }
                    else
                    {
                        TempData["RegistroMsj"] = "<p class='mb-0 text-danger'> No se pudo registrar el usuario </p>";
                    }

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    TempData["NombreUsuario"] = "<p class='mb-0 text-danger'> El nombre de usuario ya existe </p>"; 
                    return View("Registro", usuario);
                }
                
            }
            else
            {
                return View("Registro", "usuario");
            }

        }

        //BAJA
        [HttpPost]
        public ActionResult Baja(string password)
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = Session["nombreUsuario"].ToString(),
                Password = password
            };
            var usuarioResult = sesionService.Iniciar(usuario);
            TempData["Usuario"] = "<p class='mb-0 text-danger'> USUARIO:" + usuarioResult + "</p>";
            if (usuarioResult != null)
            {
                usuarioService.Eliminar1(usuarioResult);
                Session.Clear();
                TempData["Usuario"] = "< div class='alert alert-success alert-dismissible fade in'>"+
                                      "<a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>"+
                                      "<strong>Success!</strong> This alert box could indicate a successful or positive action.</div>";
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult Modificar()
        {
            var nombreUsuario = Session["nombreUsuario"].ToString();
            var usuario = usuarioService.Obtener1(nombreUsuario);
            ViewData["UsuarioEncontrado"] = usuario;
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Modificar(Usuario usuario)
        {
            var usuarioActual = Session["nombreUsuario"].ToString();
            var usuarioModif = usuarioService.Modificar(usuario, usuarioActual);
            //ViewData["UsuarioEncontrado"] = usuario;
            return View();
        }
    }
}