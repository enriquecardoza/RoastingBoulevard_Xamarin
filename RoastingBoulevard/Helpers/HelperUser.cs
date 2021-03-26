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
            string peticion = "/User";
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
        public static async Task<User> GetUser(string email,string password)
        {
            User fakeUser = new User
            {
                Email = email,
                Password = password
            };

            ByteArrayContent content = MainHelper.SerializarDato(fakeUser);
            //CREAMOS LA PETICION
            string peticion = "/User/Check";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await MainHelper.SendPeticionPost(peticion, content);
            User realUser = await MainHelper.DeserializarRespuesta<User>(respuesta);
            if (respuesta.IsSuccessStatusCode&& realUser != null && realUser.Id != -1 )
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
