



using EmployeeManagement.API;
using EmployeeManagement.API.Extensions;
using EmployeeManagementLibrary;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddMediatR(typeof(DataAccess).Assembly);
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IDataReadConnection, DataReadConnection>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddTransient<ApplicationDbContext>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCustomMiddleware();
app.MapControllers();

app.Run();
