
using System.Text.Json.Serialization;

namespace Data.Models
{
    public class Kund
    {
        public int Kundnummer { get; set; }
        public string Namn { get; set; } = string.Empty;
        public string Telefonnummer { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Projekt> Projekt { get; set; } = new();
    }
}
