using CurrencyBot.Infrastructure.Extenstions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class GetCurrencyRateByDateCommand : Command
    {
        public GetCurrencyRateByDateCommand() : base("/getRateByDate", "get getRateByDate", "examp") { }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            var request = message.Text.Split(Exts.Delimiters);
            if (request.Length <= 1)
            {
                client.SendTextMessageAsync(message.Chat, $"Будь ласка впишіть дату коректно (/getRateByDate.{DateTime.Now.ToString("yyyyMMdd")})!");
                return;
            }
            var date = message.Text.Split(Exts.Delimiters)[1];
            var rates = NBU.GetRatesByDateAsync(date).GetAwaiter().GetResult();
            StringBuilder src = new StringBuilder();
            foreach (var item in rates)
            {
                src.AppendLine($"{item.txt} - {item.rate}");
            }
            client.SendTextMessageAsync(message.Chat, src.ToString());
        }
    }
}
