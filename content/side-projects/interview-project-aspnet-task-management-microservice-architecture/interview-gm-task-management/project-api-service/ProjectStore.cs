
using System.Data;
using System.Linq;
using Dapper;
using project_api_contracts;
using project_api_contracts.Entities;

namespace project_api_service
{
  public class ProjectStore : IProjectStore
  {
    IProjectStore self;

    public ProjectStore(IDbConnection conn)
    {
      self = this;
      self.CreateTableIfNotExists(conn);
    }

    void IProjectStore.CreateProject(IDbConnection conn, Project entity)
    {
      string sql = @"INSERT INTO Project (Name, Description, CreatedBy, CreatedDate) 
                VALUES (@Name, @Description, @CreatedBy, @CreatedDate)";

      var result = conn.Execute(sql, entity);
    }

    void IProjectStore.CreateTableIfNotExists(IDbConnection conn)
    {
      var i = conn.Execute(@"
CREATE TABLE IF NOT EXISTS Project (
    Id          INTEGER           PRIMARY KEY     AUTOINCREMENT   ,
    Name        VARCHAR(100)      NOT NULL                        ,                   
    Description VARCHAR(1000)     NOT NULL                        ,                   
    CreatedBy   VARCHAR(100)      NOT NULL                        ,
    CreatedDate	varchar(50)	      NOT NULL              
);

CREATE UNIQUE INDEX IF NOT EXISTS UniqueIndex_ProjectName ON Project (Name);
");
    }

    void IProjectStore.DeleteProject(IDbConnection conn, int id)
    {
      conn.Execute("DELETE FROM Project WHERE Id = @id", new { id });
    }

    Project IProjectStore.GetProject(IDbConnection conn, int id)
    {
      var enumerable = conn.Query<Project>("SELECT * FROM Project WHERE Id = @id", new { id });
      return enumerable.FirstOrDefault();
    }
  }
}