using LeaderboardApp.Components;
using LeaderboardApp.Data;
using LeaderboardApp.Data.Interfaces;
using LeaderboardApp.Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
string? connectionString = builder.Configuration.GetConnectionString("API_KEY");

builder.Services.AddScoped<IScoreable, ScoreDbService>();

builder.Services.AddDbContext<ScoreDbContext>(options =>
    options.UseSqlite(connectionString)
);
builder.Services.AddScoped<AuthServiceable>();
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<ScoreDbService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
