using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace WebApp.Pages
{
    public class TodosModel : PageModel
    {
        public List<ToDoModel> TodoModels;
        public async Task<IActionResult> OnGet()
        {
            var client = new  RestClient("https://cosmos-api-rest.azurewebsites.net/api");
            var request = new RestRequest($"/ToDoGet?code=OS8k7CUuC3yXBm910AeXYaZvGg5SVDmCzVW3gGgiN0Ks3sYK6nN77A==", DataFormat.Json);

            var response = await client.ExecuteAsync<List<ToDoModel>>(request);
            TodoModels = response.Data;
            return Page();
        }
    }
}
