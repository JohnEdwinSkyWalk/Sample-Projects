using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
namespace JoEdAngular2.Controllers;

[ApiController]
[Route("[controller]")]
public class ExternalAPIController : ControllerBase
{
    private readonly ILogger<ExternalAPIController> _logger;

    public ExternalAPIController(ILogger<ExternalAPIController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<AllMailsModel>> Get()
    {
           List<AllMailsModel> allMailsModels = new List<AllMailsModel>();
           string apiResponse = string.Empty;
         using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts"))
                {
                     apiResponse = await response.Content.ReadAsStringAsync();
                    allMailsModels =  JsonConvert.DeserializeObject<List<AllMailsModel>>(apiResponse);
                }
            }
        return allMailsModels.AsEnumerable().ToArray();

    }
}
