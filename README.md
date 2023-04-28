# BlazorConfigExample

This is a sample project to show how to pass Options from the appsettings.json for an ASP.NET Core hosted Blazor WASM application.

The Server loads the config using the [Options pattern](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0) and then passes the config to the client using a Controller which uses a "/appsettings" route.

The client then uses a simple HttpClient call to  the "/appsettings" route and then uses the JsonDocument to parse the response into a ClientAppOptions object.

The FetchData page then uses the ClientAppOptions object to display the values from the appsettings.json file.

Because only the serving "Server" process needs to access appsettings.json, it can be secured from reading through access control methods (though use of appsettings.json for secrets is not recommended in any case) so that clients only get their options. It could also be placed behind an authorization mechanism if desired.

Note: This is a very simple example and does not include any error handling or validation.