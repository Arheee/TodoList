using Microsoft.EntityFrameworkCore;
using TodoList.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la connexion à la base de données
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI qui ajoute les services necessaire pour faire fonctionner les controleurs et vues.
builder.Services.AddControllersWithViews();
//cache en memoire pour la session 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(30); //durée de session
    option.Cookie.HttpOnly = true; // securise le cookie
    option.Cookie.IsEssential = true; // Necessaire pour les cookies de session 
});

var app = builder.Build();

//services qui initialise des données lors du démarrage de l'app.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
 }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession(); //active la session 

app.MapGet("/", context =>
{
    context.Response.Redirect("/xxxbloglalisteSooD@arkxxx");
    return Task.CompletedTask;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TodoItem}/{action=Index}/{id?}");

app.Run();
