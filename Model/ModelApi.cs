using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFornecedor.Model
{
    public class ModelApi
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("clientId")]
        public int ClientId { get; set; }
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("origin")]
        public int Origin { get; set; }
        [JsonProperty("destiny")]
        public int Destiny { get; set; }
        [JsonProperty("deliveryDate")]
        public DateTime DeliveryDate { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class PostAuction
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("auctionId")]
        public int AuctionId { get; set; }
        [JsonProperty("sellerId")]
        public int SellerId { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
    }

    public class ModelSeller
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }
        [JsonProperty("adress")]
        public string Adress { get; set; }
    }

    public class PostAuctionClose
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("clientId")]
        public int ClientId { get; set; }
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("origin")]
        public int Origin { get; set; }
        [JsonProperty("destiny")]
        public int Destiny { get; set; }
        [JsonProperty("deliveryDate")]
        public DateTime DeliveryDate { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

}