using Integration.Helper;
using PuppeteerSharp;

namespace Integration.PuppeterInegration
{
    public class PuppeterApi
    {
        private LaunchOptions options = new LaunchOptions { Headless = true, Args = new string[] { "--no-sandbox" } };

        public async Task<string> ReturnJsonFromWeb(string url)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(options);

            await using var page = await browser.NewPageAsync();

            var getsite = await page.GoToAsync(url);

            string content = await page.GetContentAsync();

            return HtmlAgilityHelper.HtmlToString(content);
        }
    }
}
