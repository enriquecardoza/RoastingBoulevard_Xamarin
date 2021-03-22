using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Helpers
{
    public class CategoryHelperAzure
    {
        public async Task<List<Category>> GetCategories()
        {
            List<Category> listadatos = null;
            //CREAMOS LA PETICION
            string peticion = MainHelper.mainRoute+"Category";
            var uri = new Uri(string.Format(peticion, string.Empty));
            var respuesta = await MainHelper.MainClient.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listadatos = JsonConvert.DeserializeObject<List<Category>>(contenido);
            }

            return listadatos;
        }

        public async Task<Category> GetCategory(string id)
        {
            Category Category = null;
            //CREAMOS LA PETICION
            string peticion = MainHelper.mainRoute + $"{id}";
            var uri = new Uri(string.Format(peticion, string.Empty));
            var respuesta = await MainHelper.MainClient.GetAsync(uri);
            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                Category = JsonConvert.DeserializeObject<Category>(contenido);
            }
            return Category;
        }
    }
}
