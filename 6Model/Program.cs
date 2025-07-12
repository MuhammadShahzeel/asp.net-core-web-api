using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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







/*
A model is a class with .cs(for C#) as an
extension having both properties(mostly) and methods.
for example a student have:
name,age,etc as properties
models are used to set and get data from the database
it is used to manage data 
we can have more than one model in a project



MODEL --> C# CLASSES --> DATA SOURCE --> DATABASE
                                     --> MANUAL LIST OR COLLECTION
we can perform CRUD operations on models

best practice to store models in models folder
create by using class 



*/