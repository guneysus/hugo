using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using user_api_contracts;
using user_api_contracts.Entities;
using Dapper;

namespace user_api_service
{

  public class UserStore : IUserStore
  {
    IUserStore self;

    public UserStore(IDbConnection conn)
    {
      self = this;
      self.CreateTableIfNotExists(conn);
    }

    bool IUserStore.CheckUsernameIsAvailable(IDbConnection conn, string username)
    {
      var sql = "SELECT COUNT(*) FROM User WHERE Username = @username";
      var result = conn.ExecuteScalar<int>(sql, new { username });
      return result == 0;
    }

    void IUserStore.CreateTableIfNotExists(IDbConnection conn)
    {
      var i = conn.Execute(@"
CREATE TABLE IF NOT EXISTS User (
    Id          INTEGER         PRIMARY KEY     AUTOINCREMENT   ,
    Username    VARCHAR(50)     NOT NULL                        ,                   
    Password    VARCHAR(50)     NOT NULL                        ,
    IsActive	INTEGER	        NOT NULL        DEFAULT         1              
);
CREATE UNIQUE INDEX IF NOT EXISTS UniqueIndex_Username ON User (Username);
");
    }

    void IUserStore.DeleteUser(IDbConnection conn, int id)
    {
      conn.Execute("DELETE FROM User WHERE Id = @id", new { id });
    }

    User IUserStore.GetUser(IDbConnection conn, int id)
    {
      var enumerable = conn.Query<User>("SELECT * FROM User WHERE Id = @id", new { id });
      return enumerable.FirstOrDefault();
    }

    void IUserStore.CreateUser(IDbConnection conn, User entity)
    {
      string sql = @"INSERT INTO User (Username, Password, IsActive) 
                VALUES (@Username, @Password, @IsActive)";

      var result = conn.Execute(sql, entity);
    }

    bool IUserStore.ValidateUsernameAndPassword(IDbConnection conn, string username, string password)
    {
      var sql = @"SELECT Password FROM User Where Username = @username";
      var pass = conn.ExecuteScalar<string>(sql, new { username });
      return password == pass;
    }

    User IUserStore.GetUserByName(IDbConnection conn, string username)
    {
      var enumerable = conn.Query<User>("SELECT * FROM User WHERE Username = @username", new { username });
      return enumerable.FirstOrDefault();
    }
  }
}
