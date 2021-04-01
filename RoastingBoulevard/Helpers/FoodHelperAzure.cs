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
        public async Task<List<Food>> GetFoods()
        {
            List<Food> listadatos = null;
            //CREAMOS LA PETICION
            string peticion = MainHelper.MainRoute+"/food";
            var uri = new Uri(string.Format(peticion, string.Empty));
            var respuesta = await MainHelper.MainClient.GetAsync(uri);
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
            string peticion = MainHelper.MainRoute + $"/{id}";
            var uri = new Uri(string.Format(peticion, string.Empty));
            var respuesta = await MainHelper.MainClient.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                food = JsonConvert.DeserializeObject<Food>(contenido);
            }
            return food;
        }
        /*
        public async Task<bool> InsertApuesta(Apuesta apuesta)
        {
            apuesta.Id = await GetMaxId();
            ByteArrayContent content = SerializarDato(apuesta);
            //CREAMOS LA PETICION
            String peticion = DireccionApi + baseController;
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await SendPeticionPost(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

    }

}

