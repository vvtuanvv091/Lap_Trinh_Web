var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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
app.MapControllerRoute(
    name: "Nhom_Ten",
    pattern: "Trang-Chu/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(
    name: "Nhom_Ten",
    pattern: "Demo-Banthan/{action=Index}/{id?}",
    defaults: new { controller = "TheLoai", action = "Index" });
app.MapControllerRoute(
    name: "proffile",
    pattern: "Profiles/{action=Profile}/{id?}",
    defaults: new { controller = "TheLoai", action = "Profile" });

app.Run();
