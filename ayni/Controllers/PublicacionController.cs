using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
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
        readonly UsuarioService usuarioService = new UsuarioService();
        readonly EstadoPublicacionService estadoPublicacionService = new EstadoPublicacionService();
        PublicacionService publicacionService = new PublicacionService();
        SesionService sesionService = new SesionService();
        readonly TransaccionService transaccionService = new TransaccionService();
        PostulacionService postulacionService = new PostulacionService();
        SaldoService saldoService = new SaldoService();
        PreguntaService preguntaService = new PreguntaService();
        UbicacionService ubicacionService = new UbicacionService();

        public PublicacionService PublicacionService { get => publicacionService; set => publicacionService = value; }

        // GET: Publicacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crearfavor()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var usuario = usuarioService.Obtener1Id(Convert.ToInt32(Session["id"]));

                string[] ubicacionSplit = usuario.Localidad.Split(new[] { ',' });
                var provinciaJToken = ubicacionService.ObtenerProvincias();
                var localidadJToken1 = ubicacionService.ObtenerLocalidad1porNombre(ubicacionSplit[0], ubicacionSplit[1].TrimStart());
                System.Diagnostics.Debug.WriteLine("usuario.Localidad: " + usuario.Localidad);
                var localidadJToken = ubicacionService.ObtenerLocalidades(localidadJToken1["provincia"]["id"].ToString());

                IList<SelectListItem> lst = new List<SelectListItem>();

                foreach (var item in localidadJToken)
                {
                    lst.Add(new SelectListItem()
                    {
                        Value = item["nombre"].ToString() + ", " + item["provincia"]["nombre"].ToString(),
                        Text = item["nombre"].ToString()
                    });
                }

                ViewBag.DropDownProvinciaActual = localidadJToken1["provincia"]["id"].ToString();
                ViewBag.DropDownLocalidadActual = usuario.Localidad;
                ViewBag.DropDownListProvincia = provinciaJToken;
                ViewBag.DropDownListLocalidad = lst;


                ViewBag.TipoPublicacion = tipoPublicacionService.Listar();
                ViewBag.Categoria = categoriaService.Listar();



                return View();
            }
        }

        [HttpPost]
        public ActionResult Crearfavor(Publicacion p, HttpPostedFileBase file) 
        {


            var valor = Request["valor-otro"];

            if (Request["valor-otro"] == "")
            {
                valor = Request["valor-check"];
            }

            p.Valor = Convert.ToInt32(valor);

            int saldo = saldoService.ObtenerSaldoUsuario(Convert.ToInt32(SessionManagement.IdUsuario));
            int? precioDePublicacionesActivas =
                publicacionService.ObtenerPrecioDePublicacionesActivas(Convert.ToInt32(SessionManagement.IdUsuario));

            if (saldo < (p.Valor +precioDePublicacionesActivas)) {
                TempData["errorSaldo"] = "*El valor del favor debe ser menor o igual a la cantidad de monedas que tengas";
                return RedirectToAction("CrearFavor","Publicacion", p);
            }
            else {
                p.idUsuario = Convert.ToInt16(Session["id"]);

                if (file != null && file.ContentLength > 0)
                {
                    var filename = Convert.ToString((p.idUsuario + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + Path.GetFileName(file.FileName)));
                    var path = Path.Combine(Server.MapPath("/Content/img_publicaciones"), filename);
                    file.SaveAs(path);
                    p.Imagen = "../Content/img_publicaciones/" + filename;
                }
                else {
                    p.Imagen = "../Content/img_publicaciones/no-image.png";
                }
                
                PublicacionService.Crearfavor(p);
                return RedirectToAction("index", "home");
            }
        }

        public ActionResult Crearofrecido()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var usuario = usuarioService.Obtener1Id(Convert.ToInt32(Session["id"]));
                string[] ubicacionSplit = usuario.Localidad.Split(new[] { ',' });
                var provinciaJToken = ubicacionService.ObtenerProvincias();
                var localidadJToken1 = ubicacionService.ObtenerLocalidad1porNombre(ubicacionSplit[0], ubicacionSplit[1].TrimStart());
                System.Diagnostics.Debug.WriteLine("usuario.Localidad: " + usuario.Localidad);
                var localidadJToken = ubicacionService.ObtenerLocalidades(localidadJToken1["provincia"]["id"].ToString());

                IList<SelectListItem> lst = new List<SelectListItem>();

                foreach (var item in localidadJToken)
                {
                    lst.Add(new SelectListItem()
                    {
                        Value = item["nombre"].ToString() + ", " + item["provincia"]["nombre"].ToString(),
                        Text = item["nombre"].ToString()
                    });
                }

                ViewBag.DropDownProvinciaActual = localidadJToken1["provincia"]["id"].ToString();
                ViewBag.DropDownLocalidadActual = usuario.Localidad;
                ViewBag.DropDownListProvincia = provinciaJToken;
                ViewBag.DropDownListLocalidad = lst;

                ViewBag.TipoPublicacion = tipoPublicacionService.Listar();
                ViewBag.Categoria = categoriaService.Listar();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Crearofrecido(Publicacion p, HttpPostedFileBase file)
        {

            var valor = Request["valor-otro"];

            if (Request["valor-otro"] == "")
            {
                valor = Request["valor-check"];
            }

            p.Valor = Convert.ToInt32(valor);

            p.idUsuario = Convert.ToInt16(Session["id"]);
            if (file != null && file.ContentLength > 0)
            {
                var filename = Convert.ToString((p.idUsuario + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + Path.GetFileName(file.FileName)));
                var path = Path.Combine(Server.MapPath("/Content/img_publicaciones"), filename);
                file.SaveAs(path);
                p.Imagen = "../Content/img_publicaciones/" + filename;
            }
            else
            {
                p.Imagen = "../Content/img_publicaciones/no-image.png";
            }

            PublicacionService.Crearofrecido(p);
            return RedirectToAction("Ofrecidos", "Home");
        }

        public ActionResult Modificar(int? idPublicacion)
        {
            ViewBag.TipoPublicacion = tipoPublicacionService.Listar();
            ViewBag.Categoria = categoriaService.Listar();
            ViewBag.EstadoPublicacion = estadoPublicacionService.Listar();
            var publicacion = PublicacionService.BuscarFavorPorIdPublicacion(idPublicacion);
            return View(publicacion);
        }

        [HttpPost]
        public ActionResult Modificar(Publicacion p, HttpPostedFileBase file)
        {

            p.idUsuario = Convert.ToInt16(Session["id"]);
            if (file != null && file.ContentLength > 0)
            {
                var filename = Convert.ToString((p.idUsuario + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + Path.GetFileName(file.FileName)));
                var path = Path.Combine(Server.MapPath("/Content/img_publicaciones"), filename);
                file.SaveAs(path);
                p.Imagen = "../Content/img_publicaciones/" + filename;
            }

            var result = PublicacionService.Modificar(p);
            if (result == 1)
            {
                TempData["MensajeModif"] = "<div class='alert alert-success'><button type='button' class='close' data-dismiss='alert'>&times;</button><p class='mb-0 text-success'> Los cambios se realizaron correctamente </p><div>";
                return RedirectToAction("Detalles", "Publicacion", new { idPublicacion = p.idPublicacion });
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
                var result = PublicacionService.Eliminar1(p);
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
        public ActionResult Detalles(int? idPublicacion)
        {
            if (Session["id"] != null) { 
            int saldo = saldoService.ObtenerSaldoUsuario(Convert.ToInt32(SessionManagement.IdUsuario));
            int? precioDePublicacionesActivas =
                publicacionService.ObtenerPrecioDePublicacionesActivas(Convert.ToInt32(SessionManagement.IdUsuario));
            Publicacion pub = publicacionService.BuscarPorID(idPublicacion);

            if ((saldo - precioDePublicacionesActivas < pub.Valor)) {
                ViewBag.SinSaldo = "No tenés la cantidad suficiente de monedas para aceptar este favor";
            }

        }

            ViewBag.Preguntas = preguntaService.BuscarPorIdPublicacion(idPublicacion);
            var publicacion = PublicacionService.BuscarFavorPorIdPublicacion(idPublicacion);
            Postulacion p = postulacionService.BuscarPorUsuarioYPublicacion(idPublicacion, Convert.ToInt32(SessionManagement.IdUsuario));
            ViewBag.YaPostulado = p;
            return View(publicacion);
        }

        public ActionResult Finalizar(int? idPublicacion)
        {
            var publicacion = PublicacionService.BuscarFavorPorIdPublicacion(idPublicacion);
            return View(publicacion);
        }

        //[HttpPost]
        //public async Task<ActionResult> Finalizar(string toAddress)
        //{
        //    int FromUserId = Convert.ToInt32(Session["id"]);
        //    await PublicacionService.Finalizar(FromUserId, toAddress);
        //    Session["saldo"] = saldoService.ObtenerSaldoUsuario(FromUserId);
        //    return RedirectToAction("Ofrecimientos", "Cuenta");
        //}

        public ActionResult Postulacion(int? idPublicacion)
        {
            Postulacion postulacionAceptada = postulacionService.BuscarAceptadaPorIdPublicacion(idPublicacion);
            Transaccion t = transaccionService.BuscarPorIdPublicacion(idPublicacion);
            
            if (postulacionAceptada != null && t != null) {
                ViewBag.postulacionAceptada = "Ya aceptaste la postulacion de " + postulacionAceptada.Usuario.Nombre + " " + postulacionAceptada.Usuario.Apellido;
                ViewBag.idTransaccion = t.idTransacion;
                ViewBag.idUsuarioAceptado = postulacionAceptada.Usuario.idUsuario;
            }

            List<Postulacion> p = postulacionService.ObtenerPorIdPublicacion(idPublicacion);
            return View(p);
        }

        public ActionResult BusquedaAvanzada(string inputBuscar, string Ubicacion, int? Categoria, int? Usuario, int? Ordenar, string AscDsc)
        {

            if (inputBuscar.Length == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {
                List<Publicacion> p = publicacionService.BuscarAvanzada(inputBuscar, Ubicacion, Categoria, Usuario, Ordenar, AscDsc);
                //var ubic = p.Select(x => x.Ubicacion).Distinct();
                ViewBag.Ubicacion = p.Select(x => x.Ubicacion).Distinct();
                //ViewBag.Audit_Status = new SelectList(db.Audits.Select(m => m.Audit_Status).Distinct(), "Audit_Status", "Audit_Status");


                List<Publicacion> ubicacionList = new List<Publicacion>();
                List<Publicacion> categoriaList = new List<Publicacion>();
                List<Publicacion> usuarioList = new List<Publicacion>();

                foreach (var item in p.GroupBy(u => u.Ubicacion).ToList())
                {
                    System.Diagnostics.Debug.WriteLine("Ubicacion:" + item.Key);

                    ubicacionList.Add(new Publicacion
                    {
                        Ubicacion = item.Key
                    });
                }

                foreach (var item in p.GroupBy(u => u.Usuario.NombreUsuario).ToList())
                {
                    System.Diagnostics.Debug.WriteLine("Usuario:" + item.Key + " Value: " + item);

                    usuarioList.Add(new Publicacion
                    {
                        Ubicacion = item.Key
                    });
                }

                ViewBag.Ubicacion = ubicacionList;
                ViewBag.Categoria = p.Select(u => u.Categoria).Distinct().ToList();
                ViewBag.Usuario = p.Select(u => u.Usuario).Distinct().ToList();
                return View(p);
            }
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
                //if (p.Count == 0)
                //{
                //    return View("sinResultados");
                //}
                return View("BusquedaAvanzada", p);
            }
        }


    }
}