using Admin.RazorWebApp.ClientServices;
using Admin.RazorWebApp.Filters;
using Admin.RazorWebApp.Handlers;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddHttpClient<AccountService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddHttpClient<ManagerService>();
builder.Services.AddScoped<ManagerService>();

builder.Services.AddHttpClient<ApartmentService>();
builder.Services.AddScoped<ApartmentService>();

builder.Services.AddHttpClient<AggregateService>();
builder.Services.AddScoped<AggregateService>();

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
