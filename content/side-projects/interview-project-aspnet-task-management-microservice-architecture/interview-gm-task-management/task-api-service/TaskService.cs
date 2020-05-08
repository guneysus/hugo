﻿using System;
using System.Data;
using AutoMapper;
using task_api_contracts;
using task_api_contracts.Entities;

namespace task_api_service
{
  public class TaskService : ITaskService
  {
    private readonly ITaskStore TaskStore;
    private readonly IDbConnection conn;
    private readonly IMapper mapper;

    public TaskService(ITaskStore TaskStore, IDbConnection conn, IMapper mapper)
    {
      this.TaskStore = TaskStore;
      this.conn = conn;
      this.mapper = mapper;
    }

    void ITaskService.CreateTask(TaskCreateModel model)
    {
      var Task = mapper.Map<Task>(model);
      Task.CreatedDate = DateTime.Now;

      this.TaskStore.CreateTask(conn, Task);
    }

    TaskCreateModel ITaskService.GetTask(int id)
    {
      var Task = TaskStore.GetTask(conn, id);
      var result = mapper.Map<TaskCreateModel>(Task);
      return result;
    }
  }
}
