using System;
using System.Data;
using System.Collections.Generic;
using user_api_contracts.Entities;

namespace user_api_contracts
{
    public interface IJWTService
    {
        string Encode(string username);
        LoginResponseModel Decode(string token);
    }
}
