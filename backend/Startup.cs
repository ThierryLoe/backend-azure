using backend;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Startup))]

namespace backend
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var sqlConnection = Environment.GetEnvironmentVariable("DbConnection");
            if (string.IsNullOrEmpty(sqlConnection)) throw new InvalidOperationException("Sql connection string could not be read");
            builder.Services.AddDbContext<ThDbContext>(options => options.UseSqlServer(sqlConnection));

        }
    }
}
