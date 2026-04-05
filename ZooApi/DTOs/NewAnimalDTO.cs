using System.Text.Json.Serialization;

namespace ZooApi.DTOs
{
    public class NewAnimalDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("species")]
        public string Species { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("health")]
        public string Health { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("feeding")]
        public string Feeding { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
