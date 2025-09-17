using Microsoft.AspNetCore.Mvc;
using SimpleSearchSite.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Register an in-memory repository
builder.Services.AddSingleton<IItemRepository, InMemoryItemRepository>();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
