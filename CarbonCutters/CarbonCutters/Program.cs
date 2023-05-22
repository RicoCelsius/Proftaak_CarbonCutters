// Program.cs

using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.IdentityModel.Logging;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });
var supportedCultures = new[] { "en-US", "nl-NL" };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

// Add services to the container.
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
    .AddMvcLocalization()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

var app = builder.Build();


app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedProto });
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
IdentityModelEventSource.ShowPII = true; //Add this line
app.UseAuthentication();
app.UseAuthorization();
var SupportedCultures = new CultureInfo[]
{
    new CultureInfo("en-US"),
    new CultureInfo("nl-NL")
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US")),
    SupportedCultures = SupportedCultures,
    SupportedUICultures = SupportedCultures
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();