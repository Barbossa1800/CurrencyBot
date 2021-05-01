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
        public GetCurrencyRateCommand() : base("/getRate", "Команда видає курс валют згідно НБУ", "/getRate") { }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            var rates = NBU.GetRatesAsync().GetAwaiter().GetResult();
            StringBuilder stb = new StringBuilder();
            foreach (var item in rates.OrderBy(d => d.Text))
            {
                stb.AppendLine($"{item.Text} - {item.Rate}");
            }
            client.SendTextMessageAsync(message.Chat, stb.ToString());
        }
    }
}
