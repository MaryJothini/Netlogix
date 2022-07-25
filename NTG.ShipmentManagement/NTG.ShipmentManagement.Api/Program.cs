using Microsoft.OpenApi.Models;
using NTG.ShipmentManagement.Api.Middleware;
using NTG.ShipmentManagement.Applicaiton;
using NTG.ShipmentManagement.Identity;
using NTG.ShipmentManagement.Infrastructure;
using NTG.ShipmentManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InstallIdentityPersistenceConfiguration(builder.Configuration);
builder.Services.InstallApplicationServices();
builder.Services.InstallPersistenceConfiguration(builder.Configuration);
builder.Services.InstallInfrastructureServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Add authorization header with Bearer [space] then token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "shipment order api", Version = "v1" });
});
builder.Services.AddCors(o =>
{
    o.AddPolicy("NTGCorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NTG.Shipment.Api v1"));
//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("NTGCorsPolicy");

app.MapControllers();

app.Run();
