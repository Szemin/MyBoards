using Microsoft.EntityFrameworkCore;
using MyBoards.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//konfiguracja połączenia na poziomie kontenera DI 
builder.Services.AddDbContext<MyBoardContext>( //rejestracja kontekstu bazy danych w DI
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyBoardsConnectionString")) 
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<MyBoardContext>();

var pendingMigrations = dbContext.Database.GetPendingMigrations();

if(pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}


app.Run();



