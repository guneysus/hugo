using System;

namespace task_api_contracts
{
    public class LoginResponseModel
    {
        public string Username { get; set; }
        public long ExpirationTime { get; set; }
    }
}

