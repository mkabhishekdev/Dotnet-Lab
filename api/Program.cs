using Microsoft.EntityFrameworkCore;
using api.Data; // <-- so Program.cs can see ApplicationDbContext


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Here is where you are adding the created db connection, Program.cs is like back of a TV, without plugging in the 
wire connections behind the TV, you can expect the TV to operate. In the same way, without adding the services in the 
Program.cs file you cannot expect the application project to work  */
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


