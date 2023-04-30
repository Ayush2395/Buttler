using Buttler.Application.Repository;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("Buttler.Application")));

builder.Services.AddDbContext<ButtlerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGetAllFoodItemsRepo, GetAllFoodItemsRepo>();
builder.Services.AddScoped<ICustomerDetailsRepo, CustomerDetailsRepo>();
builder.Services.AddScoped<ITablesRepo, TablesRepo>();
builder.Services.AddScoped<ICustomersOrderRepo, CustomersOrderRepo>();
builder.Services.AddScoped<IOrderItemsRepo, OrderItemsRepo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Buttler API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Ayush",
            Email = "ak005355@gmail.com",
            Url = new Uri("https://github.com/Ayush2395")
        },
        Description = "This is web api for buttler application.",
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "Licence",
            Url = new Uri("https://example.com")
        }
    });
});

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
