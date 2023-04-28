using BlazorConfigExample.Client;
using BlazorConfigExample.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Newtonsoft.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var config = await ReadConfigFromServer(builder.HostEnvironment.BaseAddress).ConfigureAwait(false);
builder.Services.AddSingleton(config);

await builder.Build().RunAsync();

static async Task<ClientAppOptions> ReadConfigFromServer(string baseAddress)
{
    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(baseAddress);
        var result = await client.GetAsync("appsettings");
        var content = await result.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ClientAppOptions>(content);
    }
}