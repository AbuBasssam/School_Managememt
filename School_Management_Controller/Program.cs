using School_Management_Services;
using School_Managemet_Repository.Interfaces;
using School_Managemet_Repository.Models;
using School_Managemet_Repository.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStudentRepository, StudentRepsitory>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new StudentRepsitory(connectionString!);
});

builder.Services.AddScoped<IStudent,Student>();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new TeacherRepository(connectionString!);
});

builder.Services.AddScoped<ITeacher, Teacher>();


// Add services to the container.


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
