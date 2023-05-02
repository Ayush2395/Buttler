using Buttler.API.Models;
using Buttler.Application.Repository;
using Domain.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var JWTconfig = builder.Configuration.GetSection("JWT");
builder.Services.Configure<JWTsettings>(JWTconfig);

builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("Buttler.Application")));

builder.Services.AddDbContext<ButtlerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGetAllFoodItemsRepo, GetAllFoodItemsRepo>();
builder.Services.AddScoped<ICustomerDetailsRepo, CustomerDetailsRepo>();
builder.Services.AddScoped<ITablesRepo, TablesRepo>();
builder.Services.AddScoped<ICustomersOrderRepo, CustomersOrderRepo>();
builder.Services.AddScoped<IOrderItemsRepo, OrderItemsRepo>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(opt =>
//{
//    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Buttler API",
//        Contact = new Microsoft.OpenApi.Models.OpenApiContact
//        {
//            Name = "Ayush",
//            Email = "ak005355@gmail.com",
//            Url = new Uri("https://github.com/Ayush2395")
//        },
//        Description = "This is web api for buttler application.",
//        License = new Microsoft.OpenApi.Models.OpenApiLicense
//        {
//            Name = "Licence",
//            Url = new Uri("https://example.com")
//        }
//    });
//});

builder.Services.AddSwaggerDocument(conf =>
{
    conf.PostProcess = doc =>
    {
        doc.Info.Title = "Buttler API";
        doc.Info.Version = "v1";
        doc.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "Ayush",
            Email = "ak005355@gmail.com",
            Url = "https://github.com/Ayush2395"
        };
        doc.Info.Description = "This is API for Buttler";
        doc.Info.License = new NSwag.OpenApiLicense
        {
            Name = "License",
            Url = string.Empty
        };
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
