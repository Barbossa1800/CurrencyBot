using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class GetMainCurrencyCommand : Command
    {
        public GetMainCurrencyCommand() : base("/getMain", "Команда для отримання основних валют", "/getMain") { }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            var rates = NBU.GetMainCurrenciesAsync().GetAwaiter().GetResult();
            StringBuilder stb = new StringBuilder();
            foreach (var item in rates)
            {
                stb.AppendLine($"{item.Text} - {Math.Round(item.Rate, 2)}");
            }
            client.SendTextMessageAsync(message.Chat, stb.ToString());
        }
    }
}
