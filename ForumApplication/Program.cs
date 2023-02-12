using ForumApplication.Models;
using ForumApplication.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddSingleton<IRepository<Utilisateur>, UtilisateurRepository>();
builder.Services.AddSingleton<IRepository<Forum>, ForumRepository>();
builder.Services.AddSingleton<IRepository<Post>, PostRepository>();
builder.Services.AddSingleton<IRepository<Theme>, ThemeRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
