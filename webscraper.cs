using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter the URL of the website you want to scrape: ");
            string url = Console.ReadLine();

            Console.Write("Enter the output folder path: ");
            string outputPath = Console.ReadLine();

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            await ScrapeWebsite(url, outputPath);
            Console.WriteLine("Scraping completed!");
        }

        private static async Task ScrapeWebsite(string url, string outputPath)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(content);

                string fileName = GetFileNameFromUrl(url);
                string filePath = Path.Combine(outputPath, $"{fileName}.txt");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (HtmlNode node in document.DocumentNode.DescendantsAndSelf())
                    {
                        if (!node.HasChildNodes)
                        {
                            string text = node.InnerText.Trim();
                            if (!string.IsNullOrEmpty(text))
                            {
                                writer.WriteLine(text);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Failed to load URL: {url}");
            }
        }

        private static string GetFileNameFromUrl(string url)
        {
            Uri uri = new Uri(url);
            string fileName = uri.Host + uri.AbsolutePath.Replace("/", "-");
            return fileName;
        }
    }
}
