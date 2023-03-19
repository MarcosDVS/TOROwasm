using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TORO.Client;
using TORO.Client.Managers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("TORO.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TORO.ServerAPI"));
builder.Services.AddScoped<IUsuarioRolManager, UsuarioRolManager>();
builder.Services.AddScoped<IUsuarioManager, UsuarioManager>();
builder.Services.AddScoped<IProduccionManager, ProduccionManager>();
builder.Services.AddScoped<IPreñesManager, PreñesManager>();
builder.Services.AddScoped<IPadreManager, PadreManager>();
builder.Services.AddScoped<IMadreManager, MadreManager>();
builder.Services.AddScoped<IBovinoManager, BovinoManager>();

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add(builder.Configuration.GetSection("ServerApi")["Scopes"]);
});

await builder.Build().RunAsync();
