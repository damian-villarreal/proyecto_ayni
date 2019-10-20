using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ayni.Models;
using ayni.Services;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;
using Nethereum.HdWallet;

namespace ayni.Controllers
{
    public class CuentaController : Controller
    {
        PublicacionService publicacionService = new PublicacionService();
        readonly TransaccionService transaccionService = new TransaccionService();
            


        // GET: Cuenta
        public ActionResult Pedidos()
        {
            int idUsuario = Convert.ToInt32(Session["id"]);
            List<Publicacion> p = publicacionService.BuscarPedidosPorIdUsuario(Convert.ToInt32(Session["id"]));
            ViewBag.OfrecimientosPostulados = publicacionService.BuscarPublicacionesPostuladasPorIdUsuario(idUsuario, 2);            
            return View(p);
        }

        public ActionResult Ofrecimientos()
        {
            int idUsuario = Convert.ToInt32(Session["id"]);
            List<Publicacion> p = publicacionService.BuscarOfrecimientosPorIdUsuario(idUsuario);
            ViewBag.PedidosPostulados = publicacionService.BuscarPublicacionesPostuladasPorIdUsuario(idUsuario, 1);
            return View(p);
        }

        public ActionResult Transacciones() {
           List<Transaccion> t = transaccionService.BuscarPorIdUsuario(Convert.ToInt32(Session["id"]));
            return View(t);
        }

    }
}
