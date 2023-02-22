using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using katbinapps20230221.Models;
using katbinapps20230221.Services;

namespace katbinapps20230221.Pages
{
    public class IndexModel : PageModel
    {
        public List<MyTask> MyTasks;
        private readonly IMyTaskService _taskService;

        public IndexModel(IMyTaskService taskService) 
        {
            _taskService=taskService;
        }

        public void OnGet()
        {
            MyTasks = _taskService.GetMyTasks();
        }
    }
}