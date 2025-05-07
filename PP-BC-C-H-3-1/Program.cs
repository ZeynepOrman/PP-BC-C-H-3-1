using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PP_BC_C_H_3_1.MediatR.Commands;
using WebApi.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure DB context
builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDb")));

// Configure MediatR
builder.Services.AddMediatR(typeof(UpdateBookHandler).Assembly);

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookStore API",
        Version = "v1",
        Description = "A simple ASP.NET Core Web API for Book Store operations",
        Contact = new OpenApiContact
        {
            Name = "BookStore",
            Email = "contact@bookstore.com"
        }
    });
});

// Add controllers (required for Swagger UI)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // Use Swagger in development environment
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
// Add endpoint routing for controllers (required for Swagger)
app.MapControllers();

app.Run();
