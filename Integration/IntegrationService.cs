using Integration.PuppeterInegration;
using Microsoft.Extensions.Configuration;

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
            var uri = string.Concat(_config.GetSection("ApiUrl").Value, url);
            var resultPuppeter = await _puppeterApi.ReturnJsonFromWeb(uri);

            return resultPuppeter;
        }
    }
}
