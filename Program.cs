using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Task Management API");
    });
}

//app.UseHttpsRedirection();

// fetch the tasks
app.MapGet("/api/tasks", async (AppDbContext db) =>
{
    return await db.Tasks.ToListAsync();
});

// post the tasks
app.MapPost("/api/tasks", async (TaskItem task, AppDbContext db) =>
{
    task.CreatedAt = DateTime.Now;

    db.Tasks.Add(task);

    await db.SaveChangesAsync();

    return Results.Created($"/api/tasks/{task.Id}", task);
});

//fetch a single task using its id
app.MapGet("/api/tasks/{id}", async (int id, AppDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);

    if (task is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(task);
});



app.Run();
