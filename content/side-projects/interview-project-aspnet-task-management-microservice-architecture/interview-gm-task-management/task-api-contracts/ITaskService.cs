using System;

namespace task_api_contracts
{
  public interface ITaskService {
    void CreateTask(TaskCreateModel model);
    TaskCreateModel GetTask(int id);
  }
}