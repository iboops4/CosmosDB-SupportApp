using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CosmoooDB.Models
{
    public class SupportMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required, JsonProperty("customerName")]
        public string CustomerName { get; set; } = string.Empty;

        [Required, EmailAddress, JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [Required, JsonProperty("phone")]
        public string Phone { get; set; } = string.Empty;

        [Required, JsonProperty("category")]   // 👈  matcher /category i Cosmos
        public string Category { get; set; } = string.Empty;

        [Required, JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
