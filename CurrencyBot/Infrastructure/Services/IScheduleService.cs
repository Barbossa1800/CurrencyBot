using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CurrencyBot.Infrastructure.Services
{
    public interface IScheduleService
    {
        Task ReceiveCommands(DateTime time);
    }
}