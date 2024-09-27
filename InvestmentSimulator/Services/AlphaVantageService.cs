using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class AlphaVantageService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "5ESNGT5N085SRJAI"; // Substitua pela sua chave da Alpha Vantage

    public AlphaVantageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<JObject> GetStockDataAsync(string symbol)
    {
        string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={ApiKey}";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(jsonString);
            return data;
        }

        return null;
    }
}
