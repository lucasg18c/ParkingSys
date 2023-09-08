using Accounts.Domain.Repository;
using Accounts.Infrastructure.Repository;
using JwtAuthManager;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
