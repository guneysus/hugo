using System;
using user_api_contracts.Exceptions;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using user_api_contracts;
using Moq;

namespace user_api_service_tests
{
  public class UserServiceTests : BaseTest
  {
    public UserServiceTests(DbFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public void user_register()
    {
      var service = _serviceProvider.GetService<IAccountService>();

      service.Register(new UserRegisterModel()
      {
        Username = "ahmed",
        Password = "123"
      });
    }

    [Fact]
    public void register_same_user_name_cannot_register()
    {
      var service = _serviceProvider.GetService<IAccountService>();

      service.Register(new UserRegisterModel()
      {
        Username = "ahmed",
        Password = "123"
      });

      Assert.Throws<UsernameIsNotAvailableException>(() =>
      {
        service.Register(new UserRegisterModel()
        {
          Username = "ahmed",
          Password = "000"
        });
      });
    }

    [Fact]
    public void register_username_should_not_be_empty()
    {
      var service = _serviceProvider.GetService<IAccountService>();

      Assert.Throws<RegisterUserNameCanNotBeEmpty>(() =>
      {
        service.Register(new UserRegisterModel()
        {
          Password = "foo"
        });
      });
    }

    [Fact]
    public void register_password_should_not_be_empty()
    {
      var service = _serviceProvider.GetService<IAccountService>();

      Assert.Throws<RegisterPasswordCanNotBeEmpty>(() =>
      {
        service.Register(new UserRegisterModel()
        {
          Username = "foo"
        });
      });
    }

    [Fact]
    public void login_success()
    {
      var jwt = _serviceProvider.GetService<IJWTService>();
      // var service = _serviceProvider.GetService<IAccountService>();

      var mock = new Mock<IAccountService>();
      var service = mock.Object;

      UserRegisterModel registerModel = new UserRegisterModel()
      {
        Username = "ahmed",
        Password = "123"
      };
      UserLoginModel loginModel = mapper.Map<UserLoginModel>(registerModel);

      mock
          .Setup(x => x.Login(loginModel)).Returns(jwt.Encode("ahmed"));


      service.Register(registerModel);


      var jwtToken = service.Login(loginModel);

      Assert.Equal(expected: registerModel.Username, actual: jwt.Decode(jwtToken).Username);
    }

    [Fact]
    public void login_username_fail()
    {
      var service = _serviceProvider.GetService<IAccountService>();
      var jwt = _serviceProvider.GetService<IJWTService>();

      UserRegisterModel registerModel = new UserRegisterModel()
      {
        Username = "ahmed",
        Password = "123"
      };

      service.Register(registerModel);


      Assert.Throws<UsernameOrPasswordIsWrongException>(() =>
      {
        var jwtToken = service.Login(new UserLoginModel()
        {
          Username = "foo",
          Password = registerModel.Password,
        });
      });
    }

    [Fact]
    public void login_password_fail()
    {
      var service = _serviceProvider.GetService<IAccountService>();
      var jwt = _serviceProvider.GetService<IJWTService>();

      UserRegisterModel registerModel = new UserRegisterModel()
      {
        Username = "ahmed",
        Password = "123"
      };

      service.Register(registerModel);


      Assert.Throws<UsernameOrPasswordIsWrongException>(() =>
      {
        var jwtToken = service.Login(new UserLoginModel()
        {
          Username = registerModel.Username,
          Password = "foo",

        });
      });
    }

    [Fact]
    public void login_username_should_not_be_empty()
    {
      var service = _serviceProvider.GetService<IAccountService>();
      var jwt = _serviceProvider.GetService<IJWTService>();

      UserRegisterModel registerModel = new UserRegisterModel()
      {
        Username = "ahmed",
        Password = "123"
      };

      service.Register(registerModel);

      Assert.Throws<LoginUserNameCanNotBeEmpty>(() =>
      {
        var jwtToken = service.Login(new UserLoginModel()
        {
          Password = "foo"
        });
      });
    }

    [Fact]
    public void Login_password_should_not_be_empty()
    {
      var service = _serviceProvider.GetService<IAccountService>();
      var jwt = _serviceProvider.GetService<IJWTService>();

      UserRegisterModel registerModel = new UserRegisterModel()
      {
        Username = "ahmed",
        Password = "123"
      };

      service.Register(registerModel);

      Assert.Throws<LoginPasswordCanNotBeEmpty>(() =>
      {
        var jwtToken = service.Login(new UserLoginModel()
        {
          Username = "foo"
        });
      });
    }
  }
}
