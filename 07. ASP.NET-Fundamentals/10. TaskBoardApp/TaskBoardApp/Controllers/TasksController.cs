﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Tasks;
using Task = TaskBoardApp.Data.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public TasksController(TaskBoardAppDbContext _data)
        {
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = await GetBoardsAsync()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            var boardEntities = await GetBoardsAsync();

            if (!boardEntities.Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist!");
            }

            var currentUserId = GetUserId();

            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await data.Tasks.AddAsync(task);
            await data.SaveChangesAsync();

            var boards = data.Boards;

            return RedirectToAction("All", "Boards");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await data.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Task task = await data.Tasks.FindAsync(id);


            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();

            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await GetBoardsAsync()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel formModel)
        {
            Task task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();

            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            var boards = await GetBoardsAsync();

            if (!boards.Any(b => b.Id == formModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(formModel.BoardId), "Board does not exist!");
            }

            task.Title = formModel.Title;
            task.Description = formModel.Description;
            task.BoardId = formModel.BoardId;

            await data.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Task task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();

            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            Task task = await data.Tasks.FindAsync(taskModel.Id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();

            if (currentUser != task.OwnerId)
            {
                return Unauthorized();
            }

            data.Tasks.Remove(task);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Boards");
        }

        private async Task<IEnumerable<TaskBoardModel>> GetBoardsAsync()
            => await data.Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToListAsync();

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
