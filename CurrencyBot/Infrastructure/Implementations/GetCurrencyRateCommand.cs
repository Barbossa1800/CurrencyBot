using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class GetCurrencyRateCommand : Command
    {
        public GetCurrencyRateCommand()
        {
            TextCommand = "/getRate";
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
