using Microsoft.EntityFrameworkCore;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Helpers;
using NotesApp_WebApi.Models;
using NotesApp_WebApi.Repository;
using NotesApp_WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
 


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<NotesApiDbContext>(option => option.UseInMemoryDatabase("NotesDb"));
builder.Services.AddDbContext<NotesApiDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("NoteConnectionString")));
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);




var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();
//hello
app.Run();
