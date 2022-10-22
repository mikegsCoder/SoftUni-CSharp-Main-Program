using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Tasks;
using TaskBoardApp.Data.Entities;
using Task = TaskBoardApp.Data.Entities.Task;
                                                 
namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TasksController(TaskBoardAppDbContext context)
        {
            this.data = context;
        }

        [HttpGet]
        public Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = await GetBoards()
            };

            return View(taskModel);
        }

        private async Task<IEnumerable<TaskBoardModel>> GetBoards()
        => await this.data.Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name,
            });
    }
}
