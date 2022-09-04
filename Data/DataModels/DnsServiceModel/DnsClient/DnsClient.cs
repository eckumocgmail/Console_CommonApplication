namespace Mvc0_DnsServer
{
    using static System.Console;
    using static System.Threading.Tasks.Task;
    using static System.Text.Json.JsonSerializer;
    using System.Net;
    using System.Net.Http;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    public class DnsClient   
    {
       
        private HttpClient Http { get; }
        private string Url { get;}

        public DnsClient(string host, int port)
        {
        
            Http = new HttpClient();
            this.Url = $"http://{host}:{port}/Dns";

        }

        public async Task<string> GetIp(string name)
        {
            var response = await this.Http.GetAsync($"{Url}/Get?name={name}");
            response.EnsureSuccessStatusCode();
            string text = await response.Content.ReadAsStringAsync();
            return text;
        }
        
    }
}
