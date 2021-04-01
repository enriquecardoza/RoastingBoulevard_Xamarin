using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RoastingBoulevard.Helpers
{
    public class MainHelper
    {
        private const string DireccionApi = "https://roastingboulevard.azurewebsites.net/";
        private const string ControllerApi = "api";
        private static HttpClient mainClient;
        public static HttpClient MainClient
        {
            get
            {

                if (mainClient == null)
                    mainClient = CrearCliente();
                return mainClient;


            }
            private set { mainClient = value; }
        }
        public static string MainRoute =>DireccionApi + ControllerApi;

        private static HttpClient CrearCliente()
        {
            HttpClient clientehttp = new HttpClient();
            clientehttp.DefaultRequestHeaders.Accept.Clear();
            clientehttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return clientehttp;
        }
        public static Task<HttpResponseMessage> SendPeticionGet(string peticion)
        {
            var uri = new Uri(string.Format(peticion, string.Empty));
            HttpClient client = CrearCliente();
            return client.GetAsync(uri);
        }
        public static async Task<HttpResponseMessage> SendPeticionPost(string peticion, ByteArrayContent content)
        {
            var uri = new Uri(string.Format(MainRoute+peticion, string.Empty));
            HttpClient client = CrearCliente();
            return await client.PostAsync(uri, content);
        }
        public static async Task<HttpResponseMessage> SendPeticionPut(string peticion, ByteArrayContent content)
        {
            var uri = new Uri(string.Format(MainRoute + peticion, string.Empty));
            HttpClient client = CrearCliente();
            return await client.PutAsync(uri, content);
        }
        public static ByteArrayContent SerializarDato<T>(T dato)
        {
            string jsonApuesta = JsonConvert.SerializeObject(dato, Formatting.Indented);
            //PASAMOS SUS DATOS A BYTES
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(jsonApuesta);
            //CREAMOS UN CONTENIDO DE BYTES PARA ENVIAR
            //EN LA PETICION
            ByteArrayContent content = new ByteArrayContent(buffer);
            //INDICAMOS EN LA CABECERA EL TIPO DE CONTENIDO A ENVIAR
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }
        public static async Task<T> DeserializarRespuesta<T>(HttpResponseMessage respuesta)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            T listadatos = JsonConvert.DeserializeObject<T>(contenido);

            return listadatos;
        }
    }
}
