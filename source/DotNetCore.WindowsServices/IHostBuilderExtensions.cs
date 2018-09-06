using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNetCore.WindowsServices
{
    /// <summary>
    /// To support .NET Core console apps hosted as WindowsServices 
    /// https://github.com/aspnet/Hosting/issues/1529
    /// https://github.com/aspnet/Hosting/blob/master/samples/GenericHostSample/ServiceBaseLifetime.cs
    /// </summary>
    public static class ServiceBaseLifetimeHostExtensions
    {
        public static Task RunAsServiceAsync(this IHostBuilder hostBuilder, CancellationToken cancellationToken = new CancellationToken())
        {
            return hostBuilder.UseServiceBaseLifetime().Build().RunAsync(cancellationToken);
        }

        private static IHostBuilder UseServiceBaseLifetime(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((hostContext, services) => services.AddSingleton<IHostLifetime, ServiceBaseLifetime>());
        }
    }   
}