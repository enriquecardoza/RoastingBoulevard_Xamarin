using Newtonsoft.Json;
using RoastingBoulevard.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoastingBoulevard.Helpers
{
    class DeliveryHelperAzure
    {

        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
            ByteArrayContent content = MainHelper.SerializarDato(delivery);
            //CREAMOS LA PETICION
            string peticion = "/Delivery/Insert";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await MainHelper.SendPeticionPost(peticion, content);
            // User dato = await MainHelper.DeserializarRespuesta<User>(respuesta);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<List<Delivery>> GetDeliveries(int idUser)
        {
            ByteArrayContent content = MainHelper.SerializarDato(idUser);
            List<Delivery> listadatos =new List<Delivery>();
            string peticion = $"/Delivery/GetDeliveriesFromUser";
            var respuesta = await MainHelper.SendPeticionPost(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                listadatos = await MainHelper.DeserializarRespuesta<List<Delivery>>(respuesta);
            }
            return listadatos;
        }

    }
}
