using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Helpers
{
    public class HelperUser
    {
        public static async Task<bool> InsertUser(User User)
        {
            ByteArrayContent content = MainHelper.SerializarDato(User);
            //CREAMOS LA PETICION
            string peticion = "/User/Insert";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await MainHelper.SendPeticionPost(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<User> GetUser(User fakeUser)
        {
            ByteArrayContent content = MainHelper.SerializarDato(fakeUser);
            //CREAMOS LA PETICION
            string peticion = "";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await MainHelper.SendPeticionPost(peticion, content);
            User realUser = await MainHelper.DeserializarRespuesta<User>(respuesta);
            if (respuesta.IsSuccessStatusCode&& realUser.id != -1)
            {
                return realUser;
            }
            else
            {
                return null;
            }
        }
    }
}
