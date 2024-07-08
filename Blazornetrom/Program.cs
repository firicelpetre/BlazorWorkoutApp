using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazornetrom.Components;
using Blazornetrom.Context;
using Blazornetrom.Repositories.Imlplementations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IExercicesRepository, ExercicesRepository>();
builder.Services.AddScoped<IWorkoutsRepository, WorkoutsRepository>();
builder.Services.AddScoped<IExerciseLogsRepository, ExerciseLogsRepository>();
builder.Services.AddDbContext<SmartWorkoutContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios,see see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
