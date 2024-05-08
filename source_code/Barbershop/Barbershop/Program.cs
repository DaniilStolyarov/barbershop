using Barbershop;
using Barbershop.Components;
using Barbershop.Model.Entity;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.LoadingIndicator;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons()
    .AddLoadingIndicator();
builder.Services.AddDbContextFactory<DatabaseContext>();
builder.Services.AddBlazoredLocalStorage();
// custom user services
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Fill with test data
using (var db = new DatabaseContext(true))
{
    TestData.Fill(db);
    Console.WriteLine(db.Model.ToDebugString());
}


app.Run();
