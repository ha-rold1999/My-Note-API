using Microsoft.EntityFrameworkCore;
using My_Note_API.Controllers;
using My_Note_API.EntityFramwork;
using My_Note_API.EntityFramwork.ToDoEntityFramework;
using My_Note_API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DatabaseContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddDbContext<TodoDatabaseContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
builder.Services.AddScoped<INotesController<Note>, NotesController>();
builder.Services.AddScoped<INotesController<Code>, CodesController>();
builder.Services.AddScoped<IToDoController<ToDo>, ToDoController>();
builder.Services.AddScoped(typeof(IDbHelper<>) ,typeof(DbHelper<>));
builder.Services.AddScoped(typeof(IToDoDbHelper<ToDo, Archive_ToDo>), 
    typeof(ToDoDbHelper<ToDo, Archive_ToDo, Create_ToDo_Log<ToDo>, 
    UpDate_Logger<My_Note_API.EntityFramwork.ToDoEntityFramework.ToDo>>));
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    //var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    //db.Database.Migrate();
    var todoDb = scope.ServiceProvider.GetRequiredService<TodoDatabaseContext>();
    todoDb.Database.Migrate();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
