using AndreGutierrez.Infra.Data;
using Example.Infra.CrossCutting.IoC;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(Program)); 

// Add services to the container.
NativeInjector.Setup(builder.Services, builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.WithOrigins("*")
                  .WithMethods("PUT", "DELETE", "GET", "POST")
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DesafioContext>();
    dataContext.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

//"DefaultConnection": "Data Source=sqldata,1433;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Stefanini@123"