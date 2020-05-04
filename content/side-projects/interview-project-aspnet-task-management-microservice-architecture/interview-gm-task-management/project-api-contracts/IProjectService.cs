using System;

namespace project_api_contracts
{
  public interface IProjectService {
    void CreateProject(ProjectCreateModel model);
    ProjectCreateModel GetProject(int id);
  }
}