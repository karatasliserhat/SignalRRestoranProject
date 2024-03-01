using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UdemySignalRProject.API.Hubs;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.BusinessLayer.Concreate;
using UdemySignalRProject.BusinessLayer.Mapping;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.DAL.Repositories;
using UdemySignalRProject.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDataProtection();
builder.Services.AddCors(opts =>
{

    opts.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:7203").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

builder.Services.AddDbContext<SignalRContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["SqlDbConnect"], conf =>
    {

        conf.MigrationsAssembly(Assembly.GetAssembly(typeof(SignalRContext)).GetName().Name);
    });
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();


builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IMoneyCaseService, MoneyCaseService>();
builder.Services.AddScoped<IMenuTableService, MenutTableService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();


builder.Services.AddAutoMapper(typeof(MapProfile));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
