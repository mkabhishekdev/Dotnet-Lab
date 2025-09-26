using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.Extensions.Options; // <-- so Program.cs can see ApplicationDbContext


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


/* Here is where you are adding the created db connection, Program.cs is like back of a TV, without plugging in the 
wire connections behind the TV, you can expect the TV to operate. In the same way, without adding the services in the 
Program.cs file you cannot expect the application project to work  */
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

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


