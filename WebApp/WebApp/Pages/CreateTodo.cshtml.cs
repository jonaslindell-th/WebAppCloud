using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace WebApp.Pages
{
    public class CreateTodoModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string IsFinished { get; set; }
        public void OnPost()
        {
            var todo = new ToDoModel {Title = Title, Description = Description};
            var client = new RestClient("https://cosmos-api-jonas.azurewebsites.net/api");
            var request = new RestRequest("/Add-New-ToDo?code=syEs2sb8l7DLLXMObmXp3yQa3vn6Yn2igI9T2CRT7cxEavL0ub2eHQ==");
            request.AddJsonBody(todo);
            var response = client.Post<ToDoModel>(request);
        }
    }
}
