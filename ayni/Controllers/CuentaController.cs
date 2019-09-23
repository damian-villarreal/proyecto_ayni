using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Models;
using ayni.Services;

namespace ayni.Controllers
{
    public class CuentaController : Controller
    {
        PublicacionService publicacionService = new PublicacionService();

        // GET: Cuenta
        public ActionResult Pedidos()
        {
            List<Publicacion> p = publicacionService.BuscarPedidosPorIdUsuario(Convert.ToInt32(Session["id"]));
            return View(p);
        }

        public ActionResult Ofrecimientos()
        {
            List<Publicacion> p = publicacionService.BuscarOfrecimientosPorIdUsuario(Convert.ToInt32(Session["id"]));
            return View(p);
        }

        public ActionResult Transacciones() {
            return View();
        }

    }
}
