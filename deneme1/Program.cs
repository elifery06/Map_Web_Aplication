//using deneme1.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//AddScoped<IItemService, ItemService>()
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//// app.UseSwaggerUI(c =>
////{
////    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
////    c.RoutePrefix = string.Empty;
////});
//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
//app.UseDeveloperExceptionPage();

using deneme1.Services;
using deneme1.Data;
using Microsoft.EntityFrameworkCore;
using deneme1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//veritabaný baðlantýsýý
builder.Services.AddDbContext<ItemDB>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// PostgreSQL baðlantý dizesini ayarla
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext yapýlandýrmasý
builder.Services.AddDbContext<ItemDB>(options =>
    options.UseNpgsql(connectionString));


// IItemService ve ItemService sýnýfýný dependency injection konteynerine ekleyin.
builder.Services.AddScoped<IItemService<Item>, ItemService<Item>>();

//ASP.NET Core'un IItemService arayüzü için ItemService sýnýfýný kullanmasýný saðlar. Bu þekilde, ItemsController sýnýfýnýz IItemService türünde bir hizmet talep ettiðinde, ASP.NET Core otomatik olarak ItemService sýnýfýnýn bir örneðini saðlar.

// Swagger/OpenAPI yapýlandýrmasý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP istek hattýný yapýlandýrýn.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

