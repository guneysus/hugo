using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace task_api
{
  public class AuthHelper
  {
    private readonly HttpContext context;

    public AuthHelper(IHttpContextAccessor http)
    {
      context = http.HttpContext;
    }

    public async Task<AuthenticateResult> GetAuthAsync()
    {
      AuthenticateResult authenticateResult = await context.AuthenticateAsync("Bearer");
      return authenticateResult;
    }

    public async Task<string> GetUsernameAsync()
    {
      AuthenticateResult authenticateResult = await context.AuthenticateAsync("Bearer");
      string value = authenticateResult.Principal.Claims.Where(x => x.Type == "jti").First().Value;
      return value;
    }

    public string GetToken()
    {
      var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer", string.Empty).Trim();
      return jwtToken;
    }
  }
}
