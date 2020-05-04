using System;
using System.Data;
using System.IO;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using user_api_contracts;
using user_api_service;

namespace user_api_service_tests
{
    public class BaseTest : IClassFixture<DbFixture>, IDisposable
    {

        protected IServiceProvider _serviceProvider;
        protected readonly IUserStore Db;
        protected readonly IMapper mapper;
        protected IDbConnection conn;
        private DbFixture fixture;

        public BaseTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            Db = _serviceProvider.GetService<IUserStore>();

            mapper = _serviceProvider.GetService<IMapper>();
            conn = _serviceProvider.GetRequiredService<IDbConnection>();
            this.fixture = fixture;
        }

        public BaseTest()
        {
            Db.CreateTableIfNotExists(conn);
            Db.CreateTableIfNotExists(conn);
            Db.CreateTableIfNotExists(conn);
        }


        public void Dispose()
        {
            File.Delete(fixture.DB_FILE);
        }
    }
}
