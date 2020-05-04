using System;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;


namespace Gateway
{

  public class JwtService
    {
        private readonly string SECRET;
        private readonly IConfiguration config;

        public JwtService(IConfiguration config)
        {
            SECRET = config["Jwt:Key"];
            this.config = config;
        }

        public LoginResponseModel Decode(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var loginResponseModel = decoder.DecodeToObject<LoginResponseModel>(token, SECRET, verify: true);
                return loginResponseModel;

            }
            catch (TokenExpiredException)
            {
                throw;
            }
            catch (SignatureVerificationException)
            {
                throw;
            }

        }

        public string Encode(string username)
        {
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(SECRET)
                .AddClaim("ExpirationTime", DateTimeOffset.UtcNow.AddHours(12).ToUnixTimeSeconds())
                .AddClaim("Username", username)
                .ExpirationTime(DateTime.UtcNow.AddHours(12))
                .GivenName(username)
                .Id(username)
                .Issuer(config["Jwt:Issuer"])
                .MiddleName(username)
                .Subject("Web Development")
                .Audience(config["Jwt:Issuer"])
                .Build();

            return token;
        }        
    }
}
