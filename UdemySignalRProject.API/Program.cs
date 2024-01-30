using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.BusinessLayer.Concreate;
using UdemySignalRProject.BusinessLayer.Mapping;
using UdemySignalRProject.DAL.Abstract;
using UdemySignalRProject.DAL.Concreate;
using UdemySignalRProject.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SignalRContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["SqlDbConnect"], conf =>
    {

        conf.MigrationsAssembly(Assembly.GetAssembly(typeof(SignalRContext)).GetName().Name);
    });
});
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddAutoMapper(typeof(MapProfile));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.Run();
