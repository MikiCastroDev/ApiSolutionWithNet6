using Api.Application.Config;
using Api.Application.Contracts.Config;
using Api.Application.Contracts.Services;
using Api.Application.Services;
using Api.CrossCutting.ApiCaller;
using Api.CrossCutting.Contracts.ApiCaller;
using Api.DataAccess;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Repositories;
using Api.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

#region DbContext
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<DatabaseContext> ((serviceProvider, dbContextBuilder) =>
{
    var connectionString = String.Empty;
    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    var sandbox = System.Web.HttpUtility.ParseQueryString(httpContextAccessor.HttpContext.Request.QueryString.Value).Get("sandbox");

    if ((sandbox == null) || !Convert.ToBoolean(sandbox))
        connectionString = builder.Configuration.GetConnectionString("MySQLDevelopment");
    else
        connectionString = builder.Configuration.GetConnectionString("Production");


    dbContextBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<MongoContext>();
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Dependency Injection
builder.Services.AddSingleton<IAppConfig, AppConfig>();
builder.Services.AddSingleton<IApiCaller, ApiCaller>();
builder.Services.AddScoped<IUnitOfWorkMySQL, UnitOfWorkMySQL>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWorkMongoDB, UnitOfWorkMongoDB>();
builder.Services.AddScoped<IOrderMongoRepository, OrderMongoRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

#region Logger
builder.Services.AddTransient(provider =>
{
    var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
    const string categoryName = "Log:";
    return loggerFactory.CreateLogger(categoryName);
});
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
