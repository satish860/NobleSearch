using FastEndpoints;
using Redis.OM;
using Redis.OM.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSingleton(new RedisConnectionProvider("redis://localhost:6379"));

var app = builder.Build();
app.UseFastEndpoints();
app.Run();
