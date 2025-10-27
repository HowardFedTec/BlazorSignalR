using BlazorSignalR.Components;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to require client certificates or Not.
// requiring client certificates causes SignalR to fail.
builder.Services.Configure<KestrelServerOptions>(options =>
{
    //options.ConfigureHttpsDefaults(options =>
    //    options.ClientCertificateMode = ClientCertificateMode.RequireCertificate);
    options.AddServerHeader = false;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//app.UsePathBase("/base");
//app.MapBlazorHub("/hubs");

app.MapHub<ChatHub>("/chathub");

app.Run();
