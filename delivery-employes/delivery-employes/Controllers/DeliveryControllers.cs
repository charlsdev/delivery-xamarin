using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using delivery_employes.Models;

namespace delivery_employes.Controllers
{
    public class DeliveryControllers
    {
        string urlAPI = "http://192.168.100.86:4000/api";

        public async Task<bool> SavePedido(
            string ced, string nameCom, string direc, string esta, 
            string prod, string prec, string cant
        )
        {
            Uri url = new Uri(urlAPI);

            Delivery dely = new Delivery
            {
                Cedula = ced,
                NameCompleto = nameCom,
                Direccion = direc,
                Estado = esta,
                Producto = prod,
                Precio = prec,
                Cantidad = cant,
            };

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(dely);
            var contJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, contJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Delivery>> AllDeliverys()
        {
            Uri url = new Uri(urlAPI);

            var req = new HttpRequestMessage();
            req.RequestUri = url;
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage res = await client.SendAsync(req);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                string content = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Delivery>>(content);

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeletePedido(string id)
        {
            string uri = $"{urlAPI}/{id}";

            var client = new HttpClient();

            var response = await client.DeleteAsync(uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Delivery> OnePedido(string ced)
        {
            Uri url = new Uri($"{urlAPI}/{ced}");

            var req = new HttpRequestMessage();
            req.RequestUri = url;
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage res = await client.SendAsync(req);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                string content = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Delivery>(content);

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdatePedido(
            string id, string ced, string nameCom, string direc, 
            string esta, string prod, string prec, string cant
        )
        {
            Uri url = new Uri(urlAPI);

            Delivery dely = new Delivery
            {
                Id = id,
                Cedula = ced,
                NameCompleto = nameCom,
                Direccion = direc,
                Estado = esta,
                Producto = prod,
                Precio = prec,
                Cantidad = cant,
            };

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(dely);
            var contJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, contJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
