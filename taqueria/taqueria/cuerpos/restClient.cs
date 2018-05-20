using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace scanner.cuerpos
{
    class restClient
    {
         HttpClient client;
        List<orden> find;
        public restClient() {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 2500;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Content-type", "application/json");
            //client.BaseAddress = new Uri("http://192.168.1.70:3000/orden");
        }
        public List<orden> getOrden(int usuario)
        {
            itemUsuario codigo = new itemUsuario
            {
                idUsuario = usuario
            };
            string json = JsonConvert.SerializeObject(codigo, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://ordenesrealizadas.herokuapp.com/ordenes");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            string result = JsonConvert.SerializeObject(res.Content.ReadAsStringAsync().Result, Formatting.Indented);
            if (result.Contains("exists"))
            {
                //result = "contiene";
                find = null;
            }
            else {
                //result = "no contiene";
                find = JsonConvert.DeserializeObject<List<orden>>(res.Content.ReadAsStringAsync().Result);
            }
            return find;
        }
        public void inserUser(int usuario)
        {
            itemUsuario codigo = new itemUsuario
            {
                idUsuario = usuario
            };
            string json = JsonConvert.SerializeObject(codigo, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://usuarioapp.herokuapp.com/usuario");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            //string result = JsonConvert.SerializeObject(res.Content.ReadAsStringAsync().Result, Formatting.Indented);
        }
    }
}
