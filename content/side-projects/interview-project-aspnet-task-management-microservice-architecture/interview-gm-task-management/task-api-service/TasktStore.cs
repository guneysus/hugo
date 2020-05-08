
using System.Data;
using System.Linq;
using Dapper;
using task_api_contracts;
using task_api_contracts.Entities;

namespace task_api_service
{
    public class TaskStore : ITaskStore
    {
        ITaskStore self;

        public TaskStore(IDbConnection conn)
        {
            self = this;
            self.CreateTableIfNotExists(conn);
        }

        void ITaskStore.CreateTask(IDbConnection conn, Task entity)
        {
            string sql = @"INSERT INTO Task (Name, StatusId, CreatedBy, CreatedDate, DueDate, AssigneeUserId) 
                VALUES (@Name, @StatusId, @CreatedBy, @CreatedDate, @DueDate, @AssigneeUserId)";

            var result = conn.Execute(sql, entity);
        }

        void ITaskStore.CreateTableIfNotExists(IDbConnection conn)
        {
            var i = conn.Execute(@"
CREATE TABLE IF NOT EXISTS Task (
    Id              INTEGER           PRIMARY KEY     AUTOINCREMENT   ,
    Name            VARCHAR(100)      NOT NULL                        , 
    StatusId        INTEGER           NOT NULL                        , 
    CreatedBy       VARCHAR(100)      NOT NULL                        ,
    CreatedDate	    VARCHAR(50)	      NOT NULL                        ,
    DueDate   	    VARCHAR(50)	      NOT NULL                        ,
    AssigneeUserId  INTEGER           NOT NULL                        
);

-- CREATE UNIQUE INDEX IF NOT EXISTS UniqueIndex_TaskName ON Task (Name);

");
        }

        void ITaskStore.DeleteTask(IDbConnection conn, int id)
        {
            conn.Execute("DELETE FROM Task WHERE Id = @id", new { id });
        }

        Task ITaskStore.GetTask(IDbConnection conn, int id)
        {
            var enumerable = conn.Query<Task>("SELECT * FROM Task WHERE Id = @id", new { id });
            return enumerable.FirstOrDefault();
        }
    }
}