using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.WindowsServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace console.app
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || ((IList) args).Contains("--console"));

            var webHost = new HostBuilder();
            webHost.ConfigureServices(c => c.AddSingleton<IHostedService, BackgroundWorker>());
            if (isService)
            {
                await webHost.RunAsServiceAsync();
            }
            else
            {
                await webHost.RunConsoleAsync();
            }
        }
    }

    public class BackgroundWorker : IHostedService
    {
        private bool _stopping;
        private Task _backgroundTask;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting.");
            _backgroundTask = BackgroundTask();
            return Task.CompletedTask;
        }

        private async Task BackgroundTask()
        {
            while (!_stopping)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine("BackgroundWorker is doing background work.");
            }

            Console.WriteLine("BackgroundWorker is stopping.");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("BackgroundWorker is stopping.");
            _stopping = true;
            if (_backgroundTask != null)
            {
                await _backgroundTask;
            }
        }
    }
}
