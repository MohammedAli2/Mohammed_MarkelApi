using Microsoft.EntityFrameworkCore;
using Mohammed_MarkelApi.Data;
using Mohammed_MarkelApi.Services.Claims;
using Mohammed_MarkelApi.Services.Company;

var builder = WebApplication.CreateBuilder(args);

//services - scoped - created per http request and reused
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();

builder.Services.AddControllers();

//setup for database context 
builder.Services.AddDbContext<MarkelDBContext>(options => options.UseInMemoryDatabase("InMemoryDb")); //installed Microsoft.EntityFrameworkCore.InMemory

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Initialise the database and makesure its created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MarkelDBContext>();
    context.Database.EnsureCreated();
}

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
