using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Console.Entities
{
    public class CosmosObject<T>
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "ChannelId")]
        public string ChannelId { get; set; }
        public T Item { get; set; }
    }
}
