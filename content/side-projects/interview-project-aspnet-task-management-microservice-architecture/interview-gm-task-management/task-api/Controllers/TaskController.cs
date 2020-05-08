using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task_api.Models;
using task_api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using task_api_contracts;

namespace task_api.Controllers
{
  [Route("api/[controller]/[action]")]
  public class TaskController : Controller
  {
    private readonly AuthHelper authHelper;
    private readonly ITaskService TaskService;
    private readonly IJwtService jwt;

    public TaskController(AuthHelper authHelper, ITaskService TaskService, IJwtService jwt)
    {
      this.authHelper = authHelper;
      this.TaskService = TaskService;
      this.jwt = jwt;
    }

    [HttpPost]
    public async Task CreateTask([FromBody]TaskCreateModel model)
    {
      var username = await authHelper.GetUsernameAsync();
      model.CreatedBy = username;
      TaskService.CreateTask(model);      
    }

    [HttpGet("{id:int}")]
    public async Task<TaskCreateModel> GetTask(int id)
    {
      var result = TaskService.GetTask(id);
      return result; 
    }

    [HttpGet, HttpPost]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public ErrorViewModel Error()
    {
      return new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
    }
  }
}
