using System;

namespace task_api_contracts {
  public class TaskCreateModel {
    public string Name { get; set; }
    public int StatusId { get; set; }

    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public int AssigneeUserId { get; set; }
  }
}