using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyBot.Infrastructure
{
    public class CurrencyRate
    {
        [JsonPropertyName("r030")]
        public int Code { get; set; } // Коди валют по ISO 4217
        [JsonPropertyName("txt")]
        public string Text { get; set; }
        [JsonPropertyName("rate")]
        public float Rate { get; set; }
        [JsonPropertyName("cc")]
        public string Shortname { get; set; }
        [JsonPropertyName("exchangedate")]
        public string Date { get; set; }
    }
}
