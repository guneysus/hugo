using System;
using System.Data;
using System.Collections.Generic;
using user_api_contracts.Entities;

namespace user_api_contracts
{
    public interface IUserStore
    {
        User GetUser(IDbConnection conn, int id);
        User GetUserByName(IDbConnection conn, string username);
        void CreateUser(IDbConnection conn, User entity);
        void DeleteUser(IDbConnection conn, int id);
        void CreateTableIfNotExists(IDbConnection conn);

        bool CheckUsernameIsAvailable(IDbConnection conn, string username);
        bool ValidateUsernameAndPassword(IDbConnection conn, string username, string password);
    }
}
