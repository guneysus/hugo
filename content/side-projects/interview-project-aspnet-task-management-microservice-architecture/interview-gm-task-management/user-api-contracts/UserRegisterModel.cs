using System;

namespace user_api_contracts
{
    public class UserRegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserInfoModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
    }    
}

