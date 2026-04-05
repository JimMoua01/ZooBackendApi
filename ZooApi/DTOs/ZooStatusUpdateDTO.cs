using System.Text.Json.Serialization;

namespace ZooApi.DTOs
{
    public class ZooStatusUpdateDTO
    {
        [JsonPropertyName("newStatus")]
        public string Status { get; set; }
    }
}
