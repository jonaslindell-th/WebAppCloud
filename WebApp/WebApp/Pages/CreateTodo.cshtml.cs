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
    public class CreateTodoModel : PageModel
    {
        private readonly ILogger<CreateTodoModel> _logger;
        public CreateTodoModel(ILogger<CreateTodoModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Description { get; set; }
        public void OnPost()
        {
            try
            {
                var todo = new ToDoModel {Title = Title, Description = Description};
                var client = new RestClient("https://cosmos-api-rest.azurewebsites.net/api");
                var request = new RestRequest("/Add-New-ToDo?code=BDiMc3NicpgX4y7xnjKaXcUi/vhnVsO2Ar927PM72mGrjSd7BHiskw==");
                request.AddJsonBody(todo);
                var response = client.Post<ToDoModel>(request);
                _logger.LogInformation($"Successfully saved todo: {todo.Title} to db");
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error exception: {ex}");
            }
        }
    }
}
