using Microsoft.EntityFrameworkCore;
using MyBoards.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//konfiguracja po³¹czenia na poziomie kontenera DI 
builder.Services.AddDbContext<MyBoardContext>( //rejestracja kontekstu bazy danych w DI
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyBoardsConnectionString")) 
    );


builder.Services.AddDbContext<MyBoardContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyBoardsConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

