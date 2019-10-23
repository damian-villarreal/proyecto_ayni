using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Services;
using ayni.Models;

namespace ayni.Controllers
{
    public class HomeController : Controller
    {
        PublicacionService publicacionService = new PublicacionService();

        public ActionResult Index()
        {
            List<Publicacion> p = publicacionService.ListarPedidos();

            return View(p);
        }

        public ActionResult Ofrecidos() {
            List<Publicacion> p = publicacionService.ListarOfrecidos();
            return View(p);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Buscar(string inputBuscar)
        {
            if (inputBuscar.Length == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<Publicacion> p = publicacionService.BuscarHome(inputBuscar);
                if (p.Count == 0)
                {
                    return View("sinResultados");
                }
                return View("Resultados", p);
            }
        }
    }
}