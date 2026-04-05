using System.Text.Json.Serialization;

namespace ZooApi.DTOs
{
    public class VisitorCountUpdateDTO
    {
        [JsonPropertyName("newCount")]
        public int Count { get; set; }
    }
}
