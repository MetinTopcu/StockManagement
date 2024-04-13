using StockManagement.Catalog.Application.Mapper;
using StockManagement.Catalog.Application.Service;
using StockManagement.Catalog.Application.Services;
using StockManagement.Catalog.ApplicationContracts.ServiceContracts;
using StockManagement.Catalog.Domain.RepositoryContracts;
using StockManagement.Catalog.Infrastructure;
using StockManagement.Catalog.Infrastructure.Repositories;
using StockManagement.Shared.Domain.Interfaces.Repository;
using StockManagement.Shared.Domain.Interfaces.UnitOfWork;
using StockManagement.Shared.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductItemService, ProductItemService>();

builder.Services.AddScoped<IUnitOfWork<CatalogDbContext>, UnitOfWork<CatalogDbContext>>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductItemRepository, ProductItemRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository,  CategoryRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:8081", "http://172.16.1.138")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
