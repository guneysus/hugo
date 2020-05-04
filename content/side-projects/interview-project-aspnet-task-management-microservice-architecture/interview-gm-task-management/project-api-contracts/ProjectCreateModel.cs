using System;

namespace project_api_contracts {
  public class ProjectCreateModel {
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}