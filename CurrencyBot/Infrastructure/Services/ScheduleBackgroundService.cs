using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyBot.Infrastructure.Services
{
    public class ScheduleBackgroundService : BackgroundService
    {
        private readonly IScheduleService scheduleService;

        public ScheduleBackgroundService(string token)
        {
            scheduleService = new ScheduleService(new Telegram.Bot.TelegramBotClient(token));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await scheduleService.ReceiveCommands(DateTime.Now);
                await Task.Delay(1000);
            }
        }
    }
}
