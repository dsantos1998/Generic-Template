using EnterpriseName.SolutionName.Domain.BLL;
using EnterpriseName.SolutionName.Domain.BLL.Interfaces;
using EnterpriseName.SolutionName.Interface.DLL;
using EnterpriseName.SolutionName.Interface.Interfaces.DLL;
using EnterpriseName.SolutionName.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;
using System.Globalization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Serilog

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

#endregion

#region Rate limiters

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = async (context, token) =>
    {
        await context.HttpContext.Response.WriteAsync(Validations.TooManyRequests, cancellationToken: token);
    };

    options.AddTokenBucketLimiter(policyName: "all-limiter", limiterOptions =>
    {
        limiterOptions.TokensPerPeriod = 10;
        limiterOptions.TokenLimit = 100;
        limiterOptions.ReplenishmentPeriod = TimeSpan.FromMinutes(5);
    });
});

#endregion

#region Dependency injection

builder.Services.AddTransient<IBaseBusiness, BaseBusiness>();
builder.Services.AddTransient<IBaseRepository, BaseRepository>();

#endregion

#region Culture configuration - 1º part

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

#endregion

WebApplication app = builder.Build();

#region Culture configuration - 2º part

CultureInfo[] supportedCultures =
[
    new CultureInfo("en"),
    new CultureInfo("es")
];

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"), // Predeterminate language
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider() // Support to change the language using Query String
        //new AcceptLanguageHeaderRequestCultureProvider() // Add possibility to change the language with header Accept-Language
    }
});

#endregion

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
