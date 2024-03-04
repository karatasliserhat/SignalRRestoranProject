using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using UdemySignalRProject.UI.ApiServices;
using UdemySignalRProject.UI.IApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

//controllerwithviews içerisine eklenecek kod proje seviyesinde authırize işlemi yapacaksak
//opts =>
//{
//    opts.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
//}
builder.Services.AddControllersWithViews(opts =>
{
    opts.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
{

    opts.LoginPath = new PathString("/Login/Index");
    opts.Cookie = new CookieBuilder
    {
        Name = "CookieSignalR",
        SameSite = SameSiteMode.Strict,
        HttpOnly = true,
        SecurePolicy = CookieSecurePolicy.SameAsRequest,
    };
});




builder.Services.AddScoped<ICategoryApiService, CategoryApiService>();
builder.Services.AddScoped<IProductApiService, ProductApiService>();
builder.Services.AddScoped<IAboutApiService, AboutApiService>();
builder.Services.AddScoped<IBookingApiService, BookingApiService>();
builder.Services.AddScoped<IContactApiService, ContactApiService>();
builder.Services.AddScoped<IDiscountApiService, DiscountApiService>();
builder.Services.AddScoped<ISocialMediaApiService, SocialMediaApiService>();
builder.Services.AddScoped<ITestimonialApiService, TestimonialApiService>();
builder.Services.AddScoped<IMenuTableApiService, MenuTableApiService>();
builder.Services.AddScoped<ISliderApiService, SliderApiService>();
builder.Services.AddScoped<IBasketApiService, BasketApiService>();
builder.Services.AddScoped<INotificationApiService, NotificationApiService>();
builder.Services.AddScoped<IUserApiService, UserApiService>();
builder.Services.AddScoped<IMessageApiService, MessageApiService>();

builder.Services.AddHttpClient<ICategoryApiService, CategoryApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<IProductApiService, ProductApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<IAboutApiService, AboutApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<IBookingApiService, BookingApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<IContactApiService, ContactApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<IDiscountApiService, DiscountApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<ISocialMediaApiService, SocialMediaApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<ITestimonialApiService, TestimonialApiService>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<IMenuTableApiService, MenuTableApiService>(opts =>
{

    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<ISliderApiService, SliderApiService>(opts =>
{

    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<IBasketApiService, BasketApiService>(opts =>
{

    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<INotificationApiService, NotificationApiService>(opts =>
{

    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<IUserApiService, UserApiService>(opts =>
{

    opts.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});
builder.Services.AddHttpClient<IMessageApiService, MessageApiService>(opts =>
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
