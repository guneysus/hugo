using System;

namespace user_api_contracts
{
    public interface IAccountService
    {
        void Register(UserRegisterModel model);
        string Login(UserLoginModel model);
        UserInfoModel GetUser(string username);

    }
}
