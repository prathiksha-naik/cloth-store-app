
using ClothingStore.Application.Interface;
using ClothingStore.Application.Service;
using ClothingStore.Domain.Entities;
using ClothingStore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClothStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IClothItemRepository, ClothItemRepository>();
builder.Services.AddScoped<IClothCategoryRepository, ClothCategoryRepository>();
builder.Services.AddScoped<ISizeForCloth, ClothSizeRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(ClothItemGenericRepository<>));
builder.Services.AddScoped<ClothItemService>();
builder.Services.AddScoped<ClothCategoryService>();
builder.Services.AddScoped<ClothSizeService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
