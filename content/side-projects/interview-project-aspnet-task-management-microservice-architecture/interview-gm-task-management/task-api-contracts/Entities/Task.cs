using System;

namespace task_api_contracts.Entities
{
  public class Task {
    public string Name { get; set; }
    public int StatusId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public int AssigneeUserId { get; set; }
  }
}