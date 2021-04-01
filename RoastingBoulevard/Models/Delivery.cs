using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RoastingBoulevard.Models
{
    public class Delivery
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("PaymentMethod")]
        public int PaymentMethod { get; set; }
        [JsonProperty("UserId")]
        public int UserId { get; set; }
        [JsonProperty("DeliveryState")]
        public int DeliveryState { get; set; }
        [JsonProperty("Foods")]
        public List<Food> Foods { get { return _foods; } set { _foods = value; } }
        private List<Food> _foods = new List<Food>();
        [JsonProperty("Amounts")]
        public List<int> Amounts { get { return _amounts; } set { _amounts = value; } }
        private List<int> _amounts = new List<int>();
        public enum DeliveryStateEnum
        {
            Recibido = 0, Cocinando = 1, Repartiendo = 2, Entregado = 3
        }

        public enum Method
        {
            Efectivo = 0, MasterCard = 1, Visa = 2
        }

    }
}
