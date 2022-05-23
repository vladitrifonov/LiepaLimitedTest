using LiepaLimitedTest.Domain.Contracts;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LiepaLimitedTest.BackgroundJobs
{
    public class SyncronizeBackgroundService<T> : BackgroundService
    {
        private readonly ISyncronizeManager<T> _syncronizeManager;
        public SyncronizeBackgroundService(ISyncronizeManager<T> syncronizeManager)
        {
            _syncronizeManager = syncronizeManager;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _syncronizeManager.Synchronize();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
