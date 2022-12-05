using Microsoft.EntityFrameworkCore;
using Npgsql;
using AutoMapper;
using CommandAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var dBConnectionStringBuilder = new NpgsqlConnectionStringBuilder();
dBConnectionStringBuilder.ConnectionString = 
    builder.Configuration.GetConnectionString("PostgreSqlConnection");
    dBConnectionStringBuilder.Username = builder.Configuration["UserID"];
    dBConnectionStringBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<CommandContext>(opt =>opt.UseNpgsql(dBConnectionStringBuilder.ConnectionString));

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.MapControllers();


app.Run();
