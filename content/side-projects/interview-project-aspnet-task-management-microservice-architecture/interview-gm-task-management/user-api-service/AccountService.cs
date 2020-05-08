using user_api_contracts;
using System.Data;
using AutoMapper;
using user_api_contracts.Exceptions;
using user_api_contracts.Entities;

namespace user_api_service
{
  public class AccountService : IAccountService
  {
    private readonly IUserStore userStore;
    private readonly IDbConnection conn;
    private readonly IMapper mapper;
    private readonly IJWTService jwt;

    public AccountService(IUserStore userStore, IDbConnection conn, IMapper mapper, IJWTService jwt)
    {
      this.userStore = userStore;
      this.conn = conn;
      this.mapper = mapper;
      this.jwt = jwt;
    }

    UserInfoModel IAccountService.GetUser(string username)
    {
      var user = userStore.GetUserByName(conn, username);
      var model = mapper.Map<UserInfoModel>(user);
      return model;
    }


    /// <summary>
    /// Returns JWT Token
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    string IAccountService.Login(UserLoginModel model)
    {
      if (string.IsNullOrWhiteSpace(model.Username))
        throw new LoginUserNameCanNotBeEmpty();

      if (string.IsNullOrWhiteSpace(model.Password))
        throw new LoginPasswordCanNotBeEmpty();

      if (!userStore.ValidateUsernameAndPassword(conn, model.Username, model.Password))
      {
        throw new UsernameOrPasswordIsWrongException();
      }

      var response = jwt.Encode(model.Username);
      return response;
    }

    void IAccountService.Register(UserRegisterModel model)
    {
      if (string.IsNullOrWhiteSpace(model.Username))
        throw new RegisterUserNameCanNotBeEmpty();

      if (string.IsNullOrWhiteSpace(model.Password))
        throw new RegisterPasswordCanNotBeEmpty();

      var user = mapper.Map<User>(model);

      if (!userStore.CheckUsernameIsAvailable(conn, model.Username))
      {
        throw new UsernameIsNotAvailableException();
      }

      userStore.CreateUser(conn, user);

    }
  }
}
