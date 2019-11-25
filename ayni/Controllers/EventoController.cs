using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using ayni.Services;

namespace ayni.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento

        //public string CargaJsonProvincia()
        //{
        //    string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.2/download/provincias.json";

        //    //string provinciaJson = System.IO.File.ReadAllText(path, Encoding.UTF8);
        //    var webClient = new WebClient();
        //    webClient.Encoding = Encoding.UTF8;

        //    var provinciaJson = (webClient).DownloadString(path);
        //    JObject rss = JObject.Parse(provinciaJson);
        //    var provinciaFiltro = from p in rss["provincias"] orderby p["id"] select p;
        //    var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);
        //    return jsonToOutput;
        //}

        public string CargaJsonLocalidad(string name)
        {
            UbicacionService ubicacionService = new UbicacionService();
            var items = ubicacionService.ObtenerLocalidades(name);
            var municipalidadjsonToOutput = JsonConvert.SerializeObject(items, Formatting.Indented);
            return municipalidadjsonToOutput;
        }
    }
}   