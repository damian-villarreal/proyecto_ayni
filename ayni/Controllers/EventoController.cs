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

namespace ayni.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento

        public string CargaJsonProvincia()
        {
            string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.2/download/provincias.json";

            //string provinciaJson = System.IO.File.ReadAllText(path, Encoding.UTF8);
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            var provinciaJson = (webClient).DownloadString(path);
            JObject rss = JObject.Parse(provinciaJson);
            var provinciaFiltro = from p in rss["provincias"] orderby p["id"] select p;
            var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);
            return jsonToOutput;
        }

        /*
         public JsonResult CargaJson()
        {
            string path = @"C:\Users\Manu\source\repos\ayni\ayni\Scripts\provincias.json";

            string provinciaJson = System.IO.File.ReadAllText(path, Encoding.UTF8);

            System.Diagnostics.Debug.WriteLine("Entró a CargaJsons: " + provinciaJson);
            return Json(provinciaJson);
        }
        */
        /*
        public List<string> CargaJson()
        {
            System.Diagnostics.Debug.WriteLine("Entró a CargaJsons: ");
            string path = @"C:\Users\Manu\source\repos\ayni\ayni\Scripts\provincias.json";

            string provinciaJson = System.IO.File.ReadAllText(path);
            List<string> provinciaList = JsonConvert.DeserializeObject<List<string>>(provinciaJson.provincias);

            // List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);
            System.Diagnostics.Debug.WriteLine(string.Join(", ", provinciaList.ToArray()));
            //System.Diagnostics.Debug.WriteLine("provinciaList: " + provinciaList.ToArray());
            return (provinciaList);
        }*/

        public string CargaJsonMunicipio(string name)
        {
            string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.5/download/localidades.json";

            //string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.4/download/municipios.json";

            System.Diagnostics.Debug.WriteLine("ID Provincia: " + name);
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            var municipioUrl = (webClient).DownloadString(path);
            var municipioJson = JsonConvert.DeserializeObject(municipioUrl);

            JObject rss = JObject.Parse(municipioUrl);
            var provinciaFiltro = from m in rss["localidades"] orderby m["nombre"] select m;

            //var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);

            JArray municipalidadArray = new JArray();
            //array.Add(Itemid);

            foreach (var item in provinciaFiltro)
            {
                if (item["provincia"]["id"].ToString() == name)
                {
                    System.Diagnostics.Debug.WriteLine("Provincia: " + item["provincia"]["nombre"]);
                    municipalidadArray.Add(item);
                }

            }

            foreach (var item in municipalidadArray)
            {
                System.Diagnostics.Debug.WriteLine("municipio: " + item);
                //array.Add(item["nombre"]);

            }

            var municipalidadjsonToOutput = JsonConvert.SerializeObject(municipalidadArray, Formatting.Indented);

            return municipalidadjsonToOutput;
        }
    }
}   