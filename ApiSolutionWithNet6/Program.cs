using Api.Application.Config;
using Api.Application.Contracts.Services;
using Api.Application.Services;
using Api.DataAccess;
using Api.DataAccess.Contracts;
using Api.DataAccess.Contracts.Repositories;
using Api.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
#region DbContext
builder.Services.AddDbContext<DatabaseContext>((options)=>
{
    options.UseMySql(builder.Configuration.GetConnectionString("PlanetScale"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("PlanetScale")));
});
builder.Services.Configure<MongoSettings>(options =>
{
    options.ConnectionString
        = "mongodb+srv://mikicastrodev:Zebrahead310@cluster0.fg12jcd.mongodb.net/?retryWrites=true&w=majority";
    options.Database
        = "Order";
});
builder.Services.AddSingleton<MongoContext>();
#endregion
#region Dependency Injection
builder.Services.AddScoped<IUnitOfWorkMySQL, UnitOfWorkMySQL>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWorkMongoDB, UnitOfWorkMongoDB>();
builder.Services.AddScoped<IOrderMongoRepository, OrderMongoRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
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
