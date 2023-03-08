using Microsoft.EntityFrameworkCore;
using Miu_Dashboard_6._0.models;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAntDesign();
builder.Services.AddMudServices();
builder.Services.AddDbContextFactory<miudiscordbotContext>(options =>
    options.UseMySql($"server=65.21.224.42;database=miu-discord-bot;user id=miu-discord-bot;password={File.ReadAllText("sensitive-data")}", ServerVersion.Parse("10.6.12-mariadb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.Urls.Add("http://localhost:5010");

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();