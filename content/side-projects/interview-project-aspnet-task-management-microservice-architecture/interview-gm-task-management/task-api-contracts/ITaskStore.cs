using System;
using System.Data;
using System.Collections.Generic;
using task_api_contracts.Entities;

namespace task_api_contracts
{
  public interface ITaskStore
  {
    task_api_contracts.Entities.Task GetTask(IDbConnection conn, int id);
    void CreateTask(IDbConnection conn, Task entity);

    void DeleteTask(IDbConnection conn, int id);
    void CreateTableIfNotExists(IDbConnection conn);
  }
}