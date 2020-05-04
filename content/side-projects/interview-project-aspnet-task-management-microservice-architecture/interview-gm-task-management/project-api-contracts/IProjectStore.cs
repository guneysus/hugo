using System;
using System.Data;
using System.Collections.Generic;
using project_api_contracts.Entities;

namespace project_api_contracts
{
  public interface IProjectStore
  {
    Project GetProject(IDbConnection conn, int id);
    void CreateProject(IDbConnection conn, Project entity);

    void DeleteProject(IDbConnection conn, int id);
    void CreateTableIfNotExists(IDbConnection conn);
  }
}