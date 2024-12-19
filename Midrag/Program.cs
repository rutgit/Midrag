using Microsoft.EntityFrameworkCore;
using Entities;
using Serilog;
using Microsoft.AspNetCore.Diagnostics;
using DataRepository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "logs", "log-.txt"), rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddScoped<IHomePageRepository, HomePageRepository>();
builder.Services.AddScoped<IHomePageService, HomePageService>();

builder.Services.AddDbContext<MidragContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MidragConnection"),
    b => b.MigrationsAssembly("Midrag")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policyBuilder =>
        {
            policyBuilder.WithOrigins(builder.Configuration.GetSection("Cors:AllowedOrigions").Get<string[]>())
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();  
}
else
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            if (exception != null)
            {
                Log.Error(exception, "An unhandled exception occurred.");
            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
        });
    });

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

// app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
