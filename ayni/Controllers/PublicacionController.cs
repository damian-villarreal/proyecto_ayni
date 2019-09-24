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

        // GET: Publicacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear() {
            ViewBag.TipoPublicacion = tipoPublicacionService.Listar();
            ViewBag.Categoria = categoriaService.Listar();
            return View();
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
            return View();
        }
    }
}