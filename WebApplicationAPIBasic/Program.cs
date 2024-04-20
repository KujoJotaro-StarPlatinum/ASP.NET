using Microsoft.EntityFrameworkCore;
using ASPNETProdactAndCategory.Context;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(context =>
{
    context.UseSqlServer(connString);
});

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();