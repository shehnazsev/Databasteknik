
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Tjanst
    {
        public int TjanstId { get; set; }
        public string Namn { get; set; } = string.Empty;
        public decimal PrisPerTimme { get; set; }
        [JsonIgnore]
        public List<Projekt> Projekt { get; set; } = new();
    }
}
