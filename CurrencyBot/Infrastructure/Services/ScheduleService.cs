using CurrencyBot.Infrastructure.Services.Impls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CurrencyBot.Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        private readonly ITelegramBotClient _client;

        public ScheduleService(ITelegramBotClient client)
        {
            _scheduleRepository = new EFScheduleRepository();
            _client = client;
        }

        public async Task ReceiveCommands(DateTime time)
        {
            var schedules = await _scheduleRepository.GetSchedulesByTimeAsync(time);
            schedules.ForEach(async e =>
            {
                await _client.SendTextMessageAsync(e.ChatId, "Hello by schedule");
            });
        }
    }
}
