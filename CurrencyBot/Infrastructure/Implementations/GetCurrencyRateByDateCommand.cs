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
            var request = message.Text.Split('.');
            if (request.Length <= 1)
            {
                client.SendTextMessageAsync(message.Chat, "Будь ласка впишіть дату коректно!");
                return;
            }
            var date = message.Text.Split('.')[1]; // get date thriugh form '20210401'
            // баг - выдаёт всегда за текущую дату!
            // должны быть разные названия, потому что идёт вызов обычного метода с валютой*/
            var rates = NBU.GetRatesByDateAsync(date).GetAwaiter().GetResult();
            StringBuilder src = new StringBuilder();
            foreach (var item in rates)
            {
                src.AppendLine($"{item.txt} - {item.rate}"); //erorr - null value
            }
            client.SendTextMessageAsync(message.Chat, src.ToString());
        }
    }
}
