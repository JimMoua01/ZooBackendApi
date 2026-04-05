using System.Text.Json.Serialization;

namespace ZooApi.DTOs
{
    public class AnimalStatusUpdateDTO
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
    }
}
