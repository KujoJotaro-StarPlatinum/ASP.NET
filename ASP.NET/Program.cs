using ASP.NET.Models;
using ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/watch", () => "Hello World!");
app.MapGet("/student", (string studentName) =>
{
    var student = new { Name = studentName, Age = 20 };
    return Results.Ok(student);
});
//Route param
app.MapPost("/student/{studentName}", (string studentName) =>
{
    var student = new Student
    {
        Name = studentName,
        Age = 20
    };
    return Results.Ok(student);
});
//Query param
app.MapPost("/student", ([FromQuery] string name) =>
{
    var student = new Student
    {
        Name = name,
        Age = 20
    };
    return Results.Ok(student);
});

//JSON Body
app.MapPost("/student", ([FromBody] Student student) =>
{
    return Results.Ok(student);
});

// FromQuery and FromBody
app.MapPut("/student", ([FromQuery] string studentName, [FromBody] Student student) =>
{
    return Results.Ok(student);
});
app.Run();