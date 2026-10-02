namespace TaskManagementApi.DTOs;

//The DTO contains the information that a client is allowed to provide when creating a task
public class CreateTaskDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}