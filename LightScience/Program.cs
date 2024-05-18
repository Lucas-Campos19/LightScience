using LightScience.Models;
using Microsoft.AspNetCore.SignalR;
using LightScience.Services;
using LightScience.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LightScience.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

//Configurar DbContext com uma conexão específica
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configurar regras de validação de senha
    options.Password.RequireDigit = false; // Requer pelo menos um dígito (0-9)
    options.Password.RequireLowercase = false; // Requer pelo menos uma letra minúscula (a-z)
    options.Password.RequireUppercase = false; // Requer pelo menos uma letra maiúscula (A-Z)
    options.Password.RequireNonAlphanumeric = false; // Não requer caracteres especiais
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<EmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

var app = builder.Build();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Urls.Add("http://0.0.0.0:5078");

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<DataHub>("/dataHub");

app.Run();
