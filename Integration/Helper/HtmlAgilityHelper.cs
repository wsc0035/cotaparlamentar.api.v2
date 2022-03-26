using HtmlAgilityPack;

namespace Integration.Helper
{
    public class HtmlAgilityHelper
    {
        public static string HtmlToString(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//pre");

            return htmlBody.InnerHtml;
        }
    }
}
