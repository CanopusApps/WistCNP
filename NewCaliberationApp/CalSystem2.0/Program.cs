using System;
using System.Text;
using CalSystem2._0.Concrete.IServices.IBaseDataServices;
using CalSystem2._0.Concrete.IServices.ICalbrationServices;
using CalSystem2._0.Concrete.IServices.ICommonServices;
using CalSystem2._0.Concrete.IServices.IPMServices;
using CalSystem2._0.Concrete.Services.BaseDataServices;
using CalSystem2._0.Concrete.Services.CalbrationServices;
using CalSystem2._0.Concrete.Services.CommonServices;
using CalSystem2._0.Concrete.Services.PMServices;
using CalSystem2._0.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("CalDBCon"))
);

builder.Services.AddControllers();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IBaseDataServices, BaseDataServices>();
builder.Services.AddTransient<ICurrentUserServices, CurrentUserServices>();
builder.Services.AddTransient<ICalCheckListServices, CalCheckListServices>();
builder.Services.AddTransient<IDynamicDataServices, DynamicDataServices>();
builder.Services.AddTransient<IPmServices,PmServices>();
builder.Services.AddTransient<INewCalibrationServices, NewCalibrationServices>();
builder.Services.AddTransient<ICalModelService,CalModelService>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<GlobalServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });
    c.OperationFilter<AuthOperationFilter>();
});


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(options =>
    {

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetValue<string>("JwtOptions:Issuer"),
            ValidAudience = builder.Configuration.GetValue<string>("JwtOptions:Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtOptions:SecurityKey")))
        };
    });

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder
       .AllowAnyMethod()
                    .AllowAnyHeader()
                      .WithOrigins("https://localhost:4200", "http://localhost:4200", "http://localhost:4000", "http://localhost:3001", "http://localhost:3002", "https://localhost:3000", "http://localhost:3000", "http://10.81.12.163:3000", "http://10.81.12.164:3000", "http://10.81.12.163:4000")

                      .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowCredentials();
}));

var app = builder.Build();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
   
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();