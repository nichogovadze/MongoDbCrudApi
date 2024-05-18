using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Bson.IO;
using System.Globalization;
using System.Reflection;
using System;
using MongoDbCrudApi.Services;
using System.Configuration;
using MongoDB.Driver;

namespace MongoDbCrudApi
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var mongoConfig = builder.Configuration.GetSection(nameof(MongoDbSettings));
            builder.Services.Configure<MongoDbSettings>(mongoConfig);
            
            builder.Services.AddSingleton<ItemService>();

            builder.Services.AddControllers();

            return builder;
        }
    }

    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}