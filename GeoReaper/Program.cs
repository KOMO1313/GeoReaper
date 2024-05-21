using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
namespace Geolocater
{

    public class data
    {
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string postal { get; set; }
        public string org { get; set; }

    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("ui made by KOMO all credits to ebola man");
            Console.Write(" \r\n / _` |/ _ \\/ _ \\  | '__/ _ \\/ _` | '_ \\ / _ \\ '__|\r\n| (_| |  __/ (_) | | | |  __/ (_| | |_) |  __/ |   \r\n \\__, |\\___|\\___/  |_|  \\___|\\__,_| .__/ \\___|_|   \r\n  __/ |                           | |              \r\n |___/                            |_|              ");
            Console.Title = "GeoReaper";
            Console.Write("Enter IP Adress: ");
            string ip = Console.ReadLine();
            string url = $"https://ipinfo.io/{ip}/json";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    Console.WriteLine("[+]Request Successfully Made");

                    string responseData = await response.Content.ReadAsStringAsync();
                    data ipInfo = JsonConvert.DeserializeObject<data>(responseData);

                    Console.Clear();
                    Console.WriteLine($"[Country]: {ipInfo.country}");
                    Console.WriteLine($"[City]: {ipInfo.city}");
                    Console.WriteLine($"[Coordinates]: {ipInfo.loc}");
                    Console.WriteLine($"[Postal code]: {ipInfo.postal}");
                    Console.WriteLine($"[region]: {ipInfo.region}");
                    Console.WriteLine($"[ISP]): {ipInfo.org}");
                    string[] coords = ipInfo.loc.Split(',');
                    Console.WriteLine($"Google Maps: https://www.google.com/maps/?q={coords[0]},{coords[1]}");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
