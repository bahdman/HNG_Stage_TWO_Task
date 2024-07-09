using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Implementation;
using src.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuth, AuthRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IOrganisation, OrganisationRepository>();

builder.Services.AddDbContext<src.Data.AppContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("appStr"))
    );

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
