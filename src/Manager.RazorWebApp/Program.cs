using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Manager.RazorWebApp.ClientServices;
using Shared;
using Shared.Filters;
using Shared.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddHttpContextAccessor();

#region Account Service

builder.Services.AddHttpClient<AccountService>("Account", conf =>
{
    conf.BaseAddress = new Uri(Endpoints.Account.BaseUrl);
});
builder.Services.AddScoped<AccountService>();

#endregion


#region Site Service

builder.Services.AddHttpClient<SiteService>("Site", conf =>
{
    conf.BaseAddress = new Uri(Endpoints.Apartment.BaseUrl);
});
builder.Services.AddScoped<SiteService>();

#endregion


#region Resident Service

builder.Services.AddHttpClient<ResidentService>();
builder.Services.AddScoped<ResidentService>();

#endregion





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
builder.Services.AddScoped<CheckAuthorization>();


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
