using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Models;
using ayni.Services;
using ayni.Sesiones;

namespace ayni.Controllers
{
    public class PublicacionController : Controller
    {

        TipoPublicacionService tipoPublicacionService = new TipoPublicacionService();
        CategoriaService categoriaService = new CategoriaService();
        UsuarioService usuarioService = new UsuarioService();
        EstadoPublicacionService estadoPublicacionService = new EstadoPublicacionService();
        PublicacionService publicacionService = new PublicacionService();
        SesionService sesionService = new SesionService();

        // GET: Publicacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear() {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.TipoPublicacion = tipoPublicacionService.Listar();
                ViewBag.Categoria = categoriaService.Listar();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Crear(Publicacion p) {
            
                p.idUsuario = Convert.ToInt16(Session["id"]);
                publicacionService.Crear(p);
                return RedirectToAction("index", "home");            
        }

        public ActionResult Modificar(int idPublicacion)
        {
            ViewBag.TipoPublicacion = tipoPublicacionService.Listar();
            ViewBag.Categoria = categoriaService.Listar();
            var publicacion = publicacionService.BuscarFavorPorIdPublicacion(idPublicacion);
            return View(publicacion);
        }

        [HttpPost]
        public ActionResult Modificar(Publicacion p)
        {
            var result = publicacionService.Modificar(p);
            if (result == 1)
            {
                TempData["MensajeModif"] = "<div class='alert alert-success'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-success'> Los cambios se realizaron correctamente </p><div>";
                return RedirectToAction("Detalles", "Cuenta", new { idPublicacion = p.idPublicacion });
            }
            else
            {
                TempData["MensajeModif"] = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-danger'> No se puedieron realizar cambios </p><div>";
                return RedirectToAction("Modificar", "Publicacion", new { idPublicacion = p.idPublicacion });
            }
           
        }

        [HttpPost]
        public ActionResult Baja(Publicacion p, string password)
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = Session["nombreUsuario"].ToString(),
                Password = password
            };
            var usuarioResult = sesionService.Iniciar(usuario);
            TempData["PublicacionEliminar"] = "<p class='mb-0 text-danger'> USUARIO:" + usuarioResult + "</p>";
            if (usuarioResult != null)
            {
                var result = publicacionService.Eliminar1(p);
                if (result == 1)
                {
                    TempData["MensajeModif"] = "<div class='alert alert-success'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-success'> La publicación se borró correctamente </p><div>";
                    return RedirectToAction("Pedidos", "Cuenta", new { idPublicacion = p.idPublicacion });
                }
                else
                {
                    TempData["MensajeModif"] = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-danger'> No se puediedo eliminar la publicación </p><div>";
                    return RedirectToAction("Detalles", "Cuenta", new { idPublicacion = p.idPublicacion });
                }
            }
            else
            {
                TempData["MensajeModif"] = "<div class='alert alert-danger'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-danger'> No se pudo eliminar, la contraseña no es correcta </p><div>";
                return RedirectToAction("Detalles", "Cuenta", new { idPublicacion = p.idPublicacion });
            }
            
        }
    }
}