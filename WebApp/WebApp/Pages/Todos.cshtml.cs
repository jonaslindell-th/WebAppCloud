using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace WebApp.Pages
{
    public class TodosModel : PageModel
    {
        private readonly ILogger<TodosModel> _logger;
        public TodosModel(ILogger<TodosModel> logger)
        {
            _logger = logger;
        }
        public List<ToDoModel> TodoModels;
        public async Task<IActionResult> OnGet()
        {
            try
            {
                var client = new  RestClient("https://cosmos-api-rest.azurewebsites.net/api");
                var request = new RestRequest($"/ToDoGet?code=OS8k7CUuC3yXBm910AeXYaZvGg5SVDmCzVW3gGgiN0Ks3sYK6nN77A==", DataFormat.Json);
                var response = await client.ExecuteAsync<List<ToDoModel>>(request);
                TodoModels = response.Data;
                _logger.LogInformation("Successfully retrieved todo's from db.");
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error exception: {ex}");
            }

            return Page();
        }
    }
}
