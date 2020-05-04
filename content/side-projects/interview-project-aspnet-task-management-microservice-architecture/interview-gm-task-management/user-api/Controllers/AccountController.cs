using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using user_api.Models;
using user_api_service;
using user_api_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace user_api.Controllers
{
  [Route("api/[controller]/[action]")]
  public class AccountController : Controller
  {
    private readonly IAccountService accountService;
    private readonly AuthHelper authHelper;

    public AccountController(IAccountService accountService, AuthHelper authHelper)
    {
      this.accountService = accountService;
      this.authHelper = authHelper;
    }

    [HttpPost]
    public void Register([FromBody]UserRegisterModel model)
    {
      accountService.Register(model);
      return;
    }

    [HttpPost]
    public IActionResult Login([FromBody]UserLoginModel model)
    {
      var resp = accountService.Login(model);
      return Ok(resp);
    }

    [HttpGet]
    public async Task<UserInfoModel> Info()
    {
      AuthenticateResult authenticateResult = await authHelper.GetAuthAsync();
      var username = await authHelper.GetUsernameAsync();
      var model = accountService.GetUser(username);
      return model;
    }


    [HttpGet, HttpPost]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public ErrorViewModel Error()
    {
      return new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
    }
  }
}
