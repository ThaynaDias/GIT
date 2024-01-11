using ms_travel_easy.src.Models;
using ms_travel_easy.src.Repository;
using ms_travel_easy.src.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .Configure<TravelEasyDataBaseSettings>(builder.Configuration.GetSection("TravelEasyDatabase"));

builder.Services
    .AddSingleton<IAccountRepository, AccountRepository>()
    .AddSingleton<IAccountService, AccountService>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

