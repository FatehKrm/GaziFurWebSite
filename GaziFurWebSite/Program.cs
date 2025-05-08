using BusinessLayer.Abstruct;
using BusinessLayer.Concrate;
using DataAccessLayer.Abstruct;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFrameWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GaziFurContext>();

builder.Services.AddScoped<IProductDal,EfProductDal>(); 
builder.Services.AddScoped<IProductService,ProductManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IAboutUsDal,EfAboutUsDal>();
builder.Services.AddScoped<IAboutService, AboutUsManager>();

builder.Services.AddScoped<IColorDal, EfColorDal>();
builder.Services.AddScoped<IColorService, ColorManager>();

builder.Services.AddScoped<IProductImageDal, EfProductImageDal>();
builder.Services.AddScoped<IProductImageService, ProductImageManager>();


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
