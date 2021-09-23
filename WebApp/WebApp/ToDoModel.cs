using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class ToDoModel
    {
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Description { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool IsCompleted { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime Created { get; set; }
    }
}
