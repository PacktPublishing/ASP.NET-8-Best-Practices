using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HttpClientExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _factory;

        public IndexModel(
            ILogger<IndexModel> logger,
            IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        public async Task OnGet()
        {
            // Bad use of HttpClient
            // var client = new HttpClient();

            // Still not good
            //using (var client = new HttpClient())
            //{
            //    .
            //    .
            //}

            // Best way to use HttpClient
            var client = _factory.CreateClient();
            var url = $"https://www.rickandmortyapi.com/api/character/{new Random().Next(1, Total + 1)}";
            var request = await client.GetAsync(url);
            var response = request.Content.ReadAsStringAsync();
            
        }
    }
}