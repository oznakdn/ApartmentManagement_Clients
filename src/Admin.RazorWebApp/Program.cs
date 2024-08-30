using Admin.RazorWebApp.ClientServices;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Shared;
using Shared.Filters;
using Shared.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


#region Account Service

builder.Services.AddHttpClient<AccountService>("Account", conf =>
{
    conf.BaseAddress = new Uri(Endpoints.Account.BaseUrl);
});
builder.Services.AddScoped<AccountService>();

#endregion


#region Manager Service

builder.Services.AddHttpClient<ManagerService>("Account", conf =>
{
    conf.BaseAddress = new Uri(Endpoints.Account.BaseUrl);
});
builder.Services.AddScoped<ManagerService>();

#endregion


#region Apartment Service

builder.Services.AddHttpClient<ApartmentService>("Apartment", conf =>
{
    conf.BaseAddress = new Uri(Endpoints.Apartment.BaseUrl);
});
builder.Services.AddScoped<ApartmentService>();

#endregion


#region Aggregate Service

builder.Services.AddHttpClient<AggregateService>("Aggregator", conf =>
{
    conf.BaseAddress = new Uri(Endpoints.Aggrigator.BaseUrl);
});
builder.Services.AddScoped<AggregateService>();

#endregion


builder.Services.AddHttpContextAccessor();

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

builder.Services.AddTransient<RefrehTokenHandler>();
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
