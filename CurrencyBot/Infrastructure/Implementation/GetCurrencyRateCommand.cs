using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementation
{
    public class GetCurrencyRateCommand : Command
    {
        public GetCurrencyRateCommand()
        {
            TextCommand = "/gateRate";
        }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            var rates = NBU.GetRatesAsync().GetAwaiter().GetResult();
            StringBuilder stb = new StringBuilder();
            foreach (var item in rates)
            {
                stb.AppendLine($"{item.txt} - {item.rate}");
            }
            client.SendTextMessageAsync(message.Chat, stb.ToString());
        }
    }
}
