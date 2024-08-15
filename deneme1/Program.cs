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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// IItemService aray�z� ve ItemService s�n�f�n� dependency injection konteynerine ekleyin.
builder.Services.AddScoped<IItemService, ItemService>();//ASP.NET Core'un IItemService aray�z� i�in ItemService s�n�f�n� kullanmas�n� sa�lar. Bu �ekilde, ItemsController s�n�f�n�z IItemService t�r�nde bir hizmet talep etti�inde, ASP.NET Core otomatik olarak ItemService s�n�f�n�n bir �rne�ini sa�lar.

// Swagger/OpenAPI yap�land�rmas�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP istek hatt�n� yap�land�r�n.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

