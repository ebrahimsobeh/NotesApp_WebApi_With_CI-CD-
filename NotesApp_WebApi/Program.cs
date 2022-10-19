using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Models;
using NotesApp_WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IService<Note>, NoteService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<NotesApiDbContext>(option => option.UseInMemoryDatabase("NotesDb"));
builder.Services.AddDbContext<NotesApiDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("NotesApiConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();