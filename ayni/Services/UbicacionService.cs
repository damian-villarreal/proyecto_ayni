using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ayni.Services
{
    public class UbicacionService
    {


        public IOrderedEnumerable<JToken> ObtenerProvincias()
        {
            string pathProvincia = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.2/download/provincias.json";

            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            var provinciaJson = (webClient).DownloadString(pathProvincia);
            JObject rss = JObject.Parse(provinciaJson);
            var items = rss.SelectTokens("$.provincias[?(@)]").OrderBy(p => p["id"]);
            //var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);
            return items;
        }

        public IOrderedEnumerable<JToken> ObtenerLocalidades(string name)
        {
            string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.5/download/localidades.json";

            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            var localidadesJsonUrl = (webClient).DownloadString(path);
            JObject rss = JObject.Parse(localidadesJsonUrl);
            var items = rss.SelectTokens("$.localidades[?(@.provincia.id=='" + name + "')]").OrderBy(p => p["nombre"]);
            return items;
        }

        public JToken ObtenerProvincia1Id(string name)
        {
            string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.2/download/provincias.json";

            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            var provinciaJson = (webClient).DownloadString(path);
            JObject rss = JObject.Parse(provinciaJson);
            //var provinciaFiltro = from p in rss["provincias"] orderby p["id"] select p;

            var items = rss.SelectToken("$.provincias[?(@.id=='" + name + "')]").FirstOrDefault();
            //System.Diagnostics.Debug.WriteLine("Latitud:" + items["Nombre"].ToString());
            //var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);
            return items;
        }

        public JToken ObtenerLocalidad1Id(string name) 
        {
            string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.5/download/localidades.json";
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            var localidadesJsonUrl = (webClient).DownloadString(path);
            JObject rss = JObject.Parse(localidadesJsonUrl);

            var items = rss.SelectTokens("$.localidades[?(@.id=='" + name + "')]").FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("Localidad.ID:" + name +"tope");
            //var items = rss.SelectTokens("$.localidades[?(@.provincia.id=='" + name + "')]").OrderBy(p => p["nombre"]);
            System.Diagnostics.Debug.WriteLine("Localidad:" + items);
            //var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);
            return items;
        }

        public JToken ObtenerLocalidad1porNombre(string localidad, string provincia)
        {
            string path = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.5/download/localidades.json";
            var webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            var localidadesJsonUrl = (webClient).DownloadString(path);
            JObject rss = JObject.Parse(localidadesJsonUrl);

            var items = rss.SelectTokens("$.localidades[?(@.nombre=='" + localidad + "'&&@.provincia.nombre=='"+ provincia + "')]").FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("Localidad.ID:" + localidad + " || provincia: "+ provincia);
            //var items = rss.SelectTokens("$.localidades[?(@.provincia.id=='" + name + "')]").OrderBy(p => p["nombre"]);
            System.Diagnostics.Debug.WriteLine("Localidad:" + items);
            //var jsonToOutput = JsonConvert.SerializeObject(provinciaFiltro, Formatting.Indented);
            return items;
        }
    }
}