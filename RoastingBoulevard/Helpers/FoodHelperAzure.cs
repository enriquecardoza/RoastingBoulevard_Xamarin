using Newtonsoft.Json;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RoastingBoulevard.Helpers
{
    class FoodHelperAzure
    {
        private const string DireccionApi = "https://apicruddoctores.azurewebsites.net/";
        private const string ControllerApi = "api/foods";
        private HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }


        public async Task<List<Food>> GetFoods()
        {
            List<Food> listadatos = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + ControllerApi;
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Food>>(contenido);
            }
            return listadatos;
        }

        public async Task<Food> GetFoods(string id)
        {
            Food food = null;
            //CREAMOS LA PETICION
            String peticion = DireccionApi + ControllerApi+ $"{id}";
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            var respuesta = await client.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                food = JsonConvert.DeserializeObject<Food>(contenido);
            }
            return food;
        }

    }

}
}
