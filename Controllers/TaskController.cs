using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers;
// Declaring the API controller class
[ApiController]

//Declaring the base URL for the controller
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    // Store the database context
    private readonly AppDbContext _context;

    // Provide a AppDBContext when the controller is created
    public TaskController(AppDbContext context)
    {
        _context = context;
    }

    // Fetch all of the tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    // Fetch task by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if(task is null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    // Create a task
    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
    {
        task.CreatedAt = DateTime.Now;

        _context.Tasks.Add(task);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTask),
            new { id = task.Id },
            task);
    }

    // Update a task
    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItem>> UpdateTask(
        int id,
        TaskItem updatedTask)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task is null)
        {
            return NotFound();
        }

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.IsCompleted = updatedTask.IsCompleted;

        await _context.SaveChangesAsync();

        return Ok(task);

    }

    // Delete a task
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task is null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}