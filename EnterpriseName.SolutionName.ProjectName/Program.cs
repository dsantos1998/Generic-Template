using EnterpriseName.SolutionName.Domain.BLL;
using EnterpriseName.SolutionName.Domain.BLL.Interfaces;
using EnterpriseName.SolutionName.Interface.DLL;
using EnterpriseName.SolutionName.Interface.Interfaces.DLL;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
