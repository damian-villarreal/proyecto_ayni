﻿using ayni.Models;
using ayni.Services;
using ayni.Sesiones;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
        UbicacionService ubicacionService = new UbicacionService();

        // GET: Usuario
        public ActionResult Registro()
        {
            ViewBag.Message = "Regístrese en esta sección.";

            var provinciaFiltro = ubicacionService.ObtenerProvincias();
            //var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);
            //IList<SelectListItem> lst = new List<SelectListItem>();

            //foreach (var item in provinciaFiltro)
            //{
            //    System.Diagnostics.Debug.WriteLine("PROVINCIA = iso_nombre:" + item["iso_nombre"]+ " id: " + item["id"]);
            //    lst.Add(new SelectListItem()
            //    {
            //        Value = item["id"].ToString(),    
            //        Text = item["iso_nombre"].ToString()
            //    });
            //}
            ViewBag.DropDownList = provinciaFiltro;

            //return jsonToOutput;
            return View();
        }

        [HttpPost]
        async public Task<ActionResult> Alta(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                var usuarioExistente = usuarioService.Obtener1(usuario.NombreUsuario);
                if(usuarioExistente == null && ModelState.IsValid)
                {
                    await usuarioService.Alta(usuario);
                    sesionService.Iniciar(usuario);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    TempData["NombreUsuario"] = "El nombre de usuario ya existe"; 
                    return View("Registro", usuario);
                }
                
            }
            else
            {
                return View("Registro", usuario);
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
            ViewBag.Message = "Modifique sus datos en esta sección.";

            var provinciaJToken = ubicacionService.ObtenerProvincias();
            var localidadJToken1 = ubicacionService.ObtenerLocalidad1Id(usuario.Localidad);
            System.Diagnostics.Debug.WriteLine("usuario.Localidad: " + usuario.Localidad);
            var localidadJToken = ubicacionService.ObtenerLocalidades(localidadJToken1["provincia"]["id"].ToString());

            //var listLocalidad = new SelectListItem();

            IList<SelectListItem> lst = new List<SelectListItem>();

            foreach (var item in localidadJToken)
            {
                //System.Diagnostics.Debug.WriteLine("PROVINCIA = iso_nombre:" + item["iso_nombre"] + " id: " + item["id"]);
                lst.Add(new SelectListItem()
                {
                    Value = item["id"].ToString(),
                    Text = item["nombre"].ToString()
                });
            }


            //System.Diagnostics.Debug.WriteLine("Localidad: " + localidadJToken1["provincia"].ToString());

            ViewBag.DropDownProvinciaActual = localidadJToken1["provincia"]["id"].ToString();
            ViewBag.DropDownListProvincia = provinciaJToken;
            ViewBag.DropDownListLocalidad = lst;
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

        public ActionResult Perfil(int? idUsuario) {
            Usuario u = usuarioService.Obtener1Id(Convert.ToInt32(idUsuario));
            return View(u);
        }
    }
}