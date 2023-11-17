using BackEndC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringPgSql = builder.Configuration.GetConnectionString("PostgreConn");
builder.Services.AddDbContext<BackDbContext>(context => context.UseNpgsql(connectionStringPgSql)); ;

builder.Services.AddControllersWithViews();

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
// Add this line to configure the Endpoints for Controllers and Views
app.MapDefaultControllerRoute();

app.Run();
