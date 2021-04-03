using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RoastingBoulevard.Data;
using RoastingBoulevard.Models;

namespace RoastingBoulevard.Helpers
{
    public class HelperUserAzure
    {
        public static async Task<int> InsertUser(User User)
        {
            User.Id = 20;
            ByteArrayContent content = MainHelper.SerializarDato(User);
            //CREAMOS LA PETICION
            string peticion = "/User";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await MainHelper.SendPeticionPost(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                int id= await MainHelper.DeserializarRespuesta<int>(respuesta);
                return id;
            }
            else
            {
                return -1;
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
            string peticion = "/User/GetUserFromEmailAndPassword";
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
        public static async Task<int> CheckIfEmailExists(string email)
        {
            ByteArrayContent content = MainHelper.SerializarDato(email);
            //CREAMOS LA PETICION
            string peticion = "/User/CheckIfEmailExists";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await MainHelper.SendPeticionPost(peticion, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return await MainHelper.DeserializarRespuesta<bool>(respuesta) == true ? 1 : 0;
            }
            else
            {
                return -1;
            }
        }

        public static async Task<bool> EditUser(User User)
        {
            ByteArrayContent content = MainHelper.SerializarDato(User);
            //CREAMOS LA PETICION
            string peticion = "/User";
            //REALIZAMOS LA LLAMADA AL API POST ENVIANDO EL CONTENIDO
            var respuesta = await MainHelper.SendPeticionPut(peticion, content);
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
    }
}
