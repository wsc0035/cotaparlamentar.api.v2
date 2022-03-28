using Integration.PuppeterInegration;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Integration
{
    public class IntegrationService
    {
        private readonly PuppeterApi _puppeterApi;
        private readonly IConfiguration _config;
        public IntegrationService(PuppeterApi puppeterApi, IConfiguration config)
        {
            _puppeterApi = puppeterApi;
            _config = config;
        }

        public async Task<string> GetPuppeterResult(string url)
        {
            var uri = string.Concat(_config.GetSection("ApiUrl2").Value, url);
            var resultPuppeter = await _puppeterApi.ReturnJsonFromWeb(uri);

            return resultPuppeter;
        }

        public async Task<List<T>> BuscaPorUrlLista<T>(string url)
        {
            var ApiUrl = Environment.GetEnvironmentVariable("ApiUrl");
            var uri = string.Concat(ApiUrl, url);

            var client = await new HttpClient().GetAsync(uri);

            var result = client.Content.ReadAsStringAsync().Result;

            var jsonReturn = JsonSerializer.Deserialize<List<T>>(result);

            return jsonReturn;
        }
    }
}
