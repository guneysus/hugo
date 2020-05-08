﻿using System;
using System.Data;
using AutoMapper;
using project_api_contracts;
using project_api_contracts.Entities;

namespace project_api_service
{
  public class ProjectService : IProjectService
  {
    private readonly IProjectStore projectStore;
    private readonly IDbConnection conn;
    private readonly IMapper mapper;

    public ProjectService(IProjectStore projectStore, IDbConnection conn, IMapper mapper)
    {
      this.projectStore = projectStore;
      this.conn = conn;
      this.mapper = mapper;
    }

    void IProjectService.CreateProject(ProjectCreateModel model)
    {
      var project = mapper.Map<Project>(model);
      project.CreatedDate = DateTime.Now;

      this.projectStore.CreateProject(conn, project);
    }

    ProjectCreateModel IProjectService.GetProject(int id)
    {
      var project = projectStore.GetProject(conn, id);
      var result = mapper.Map<ProjectCreateModel>(project);
      return result;
    }
  }
}
