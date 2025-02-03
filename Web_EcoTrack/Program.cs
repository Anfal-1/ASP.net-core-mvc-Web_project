using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// ≈÷«›… Œœ„«  MVC
builder.Services.AddControllersWithViews();

// ≈÷«›… Œœ„… HTTP Client
builder.Services.AddHttpClient();

//  ÂÌ∆… Œœ„«  «· ÊÿÌ‰ (Localization)
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),
        new CultureInfo("ar")
    };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

//  ÂÌ∆… ÷€ÿ «·«” Ã«»«  (Response Compression)
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Optimal;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Optimal;
});
builder.WebHost.UseUrls("http://0.0.0.0:80");
var app = builder.Build();

//  ÂÌ∆… Œÿ √‰«»Ì» «·ÿ·»«  (Middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

//  ÂÌ∆… «·„·›«  «·À«» … (Static Files) Ê≈÷«›… «· Œ“Ì‰ «·„ƒﬁ 
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=86400");
    }
});

//  ÂÌ∆… «· ÊÃÌÂ (Routing)
app.UseRouting();

//  ÿ»Ìﬁ ÷€ÿ «·«” Ã«»…
app.UseResponseCompression();

//  ÿ»Ìﬁ «· ÊÿÌ‰ (Localization)
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value;
if (localizationOptions != null)
{
    app.UseRequestLocalization(localizationOptions);
}

//  ⁄ÌÌ‰ «·„”«—«  «·«› —«÷Ì…
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();