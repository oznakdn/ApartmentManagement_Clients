using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Manager.RazorWebApp;
using Manager.RazorWebApp.ClientServices;
using Manager.RazorWebApp.Filters;
using Manager.RazorWebApp.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient<AccountService>("Account", conf =>
{
    conf.BaseAddress = new Uri(Endpoints.AccountBase);
});
builder.Services.AddHttpClient<SiteService>("Site", conf=>
{
    conf.BaseAddress = new Uri(Endpoints.ApartmentBase);
});
builder.Services.AddHttpClient<ResidentService>();



builder.Services.AddAuthentication("AuthScheme")
    .AddCookie("AuthScheme", options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddNotyf(conf =>
{
    conf.Position = NotyfPosition.TopRight;
    conf.DurationInSeconds = 3;
    conf.IsDismissable = true;
    conf.HasRippleEffect = true;
});

builder.Services.AddTransient<AuthorizationHandler>();
builder.Services.AddScoped<TokenCheckFilter>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<SiteService>();
builder.Services.AddScoped<ResidentService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
