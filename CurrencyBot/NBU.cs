using CurrencyBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyBot
{
    public class NBU
    {
        public static async Task<List<CurrencyRate>> GetRatesAsync()
        {
            using var httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<List<CurrencyRate>>("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
        }
        public static async Task<List<CurrencyRate>> GetRatesByDateAsync(string date)
        {
            using var httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<List<CurrencyRate>>($"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date={date}&json");
        }

        public static async Task<List<CurrencyRate>> GetMainCurrenciesAsync()
        {
            using var httpClient = new HttpClient();
            var currencies = await httpClient.GetFromJsonAsync<List<CurrencyRate>>("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            return currencies
                .Where(d => d.Text.Contains("Росій") || d.Text.Contains("США") || d.Text.Contains("Євро"))
                .OrderBy(d => d.Rate)
                .ToList();
        }
    }
}
