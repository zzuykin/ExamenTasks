using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Task20Second.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecondController : Controller
    {
        private readonly HttpClient _httpClient;

        public SecondController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IEnumerable<MyObject>> Get()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7049/First");
            var myObjects = JsonConvert.DeserializeObject<List<MyObject>>(response);
            return myObjects;
        }
    }
}
public class MyObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}