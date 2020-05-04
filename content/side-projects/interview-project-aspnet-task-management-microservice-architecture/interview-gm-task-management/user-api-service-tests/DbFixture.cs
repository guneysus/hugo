using System;
using System.Data;
using System.Data.SQLite;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using user_api_contracts;
using user_api_service;

namespace user_api_service_tests
{
    public class DbFixture
    {
        public string DB_FILE { get; }
        public string CONNECTION_STRING { get; }

        public DbFixture()
        {
            var services = new ServiceCollection();
            //serviceCollection
            //    .AddDbContext<SomeContext>(options => options.UseSqlServer("connection string"),
            //        ServiceLifetime.Transient);

            services.AddTransient<IUserStore, UserStore>();

            services.AddTransient<IAccountService, AccountService>();

            #region IConfiguration
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            services.AddTransient<IConfiguration>(x => configurationBuilder.Build());
            #endregion

            DB_FILE = $"{Guid.NewGuid().ToString().ToLower()}.sqlite3";

            var conn = new SQLiteConnection($"Data Source={DB_FILE};Version=3;");

            services.AddTransient<IDbConnection, SQLiteConnection>(x => conn);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(profile: new AutoMapperDefaultProfile("ProjectAutoMapperProfile"));
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());

            services.AddTransient<IJWTService, JwtService>();

            ServiceProvider = services.BuildServiceProvider();


        }

        public IServiceProvider ServiceProvider { get; private set; }

    }
}
