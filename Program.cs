using Microsoft.EntityFrameworkCore;
using TodoList.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la connexion � la base de donn�es
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// DI qui ajoute les services necessaire .
builder.Services.AddControllersWithViews();
var app = builder.Build();

//services qui initialise des donn�es lors du d�marrage de l'app.
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

app.MapGet("/", context =>
{
    context.Response.Redirect("/xxxbloglalisteSooD@arkxxx");
    return Task.CompletedTask;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TodoItem}/{action=Index}/{id?}");

app.Run();
