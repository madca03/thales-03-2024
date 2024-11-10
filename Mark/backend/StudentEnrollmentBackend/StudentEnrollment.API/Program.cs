using Serilog;
using StudentEnrollment.API.Filters;
using StudentEnrollment.Business.Repository;
using StudentEnrollment.Business.Services;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Configure logger
builder.Host.UseSerilog();

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("AppDatabase");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddRepositories(connectionString, Log.Logger);
builder.Services.AddServices();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
