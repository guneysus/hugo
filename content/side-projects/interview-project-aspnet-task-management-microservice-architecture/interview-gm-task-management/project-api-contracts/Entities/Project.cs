using System;

namespace project_api_contracts.Entities
{
  public class Project {
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}