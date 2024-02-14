using UdemySignalRProject.UI.ApiServices;
using UdemySignalRProject.UI.IApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryApiService,CategoryApiService>();
builder.Services.AddHttpClient<ICategoryApiService, CategoryApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddDataProtection();

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
