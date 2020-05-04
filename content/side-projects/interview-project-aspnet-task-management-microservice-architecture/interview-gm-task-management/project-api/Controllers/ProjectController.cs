using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project_api.Models;
using project_api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using project_api_contracts;

namespace project_api.Controllers
{
  [Route("api/[controller]/[action]")]
  public class ProjectController : Controller
  {
    private readonly AuthHelper authHelper;
    private readonly IProjectService projectService;
    private readonly IJwtService jwt;

    public ProjectController(AuthHelper authHelper, IProjectService projectService, IJwtService jwt)
    {
      this.authHelper = authHelper;
      this.projectService = projectService;
      this.jwt = jwt;
    }

    [HttpPost]
    public async Task CreateProject([FromBody]ProjectCreateModel model)
    {
      var username = await authHelper.GetUsernameAsync();
      model.CreatedBy = username;
      projectService.CreateProject(model);      
    }

    [HttpGet("{int:id}")]
    public async Task<ProjectCreateModel> GetProject(int id)
    {
      var result = projectService.GetProject(id);
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
