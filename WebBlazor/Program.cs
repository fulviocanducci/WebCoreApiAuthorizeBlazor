using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebBlazor
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddScoped<Models.IDataAccess, Models.DataAccess>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
