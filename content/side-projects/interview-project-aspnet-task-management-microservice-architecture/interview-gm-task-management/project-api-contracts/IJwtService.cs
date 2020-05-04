using System;
using System.Data;
using System.Collections.Generic;
using project_api_contracts.Entities;

namespace project_api_contracts
{
    public interface IJwtService
    {
        string Encode(string username);
        LoginResponseModel Decode(string token);
    }
}
