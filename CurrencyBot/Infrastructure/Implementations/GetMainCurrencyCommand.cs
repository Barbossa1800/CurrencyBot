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
        public GetMainCurrencyCommand() : base("/getMain", "Отримання головних валют", "/getMain") { }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            var rates = NBU.GetMainCurrenciesAsync().GetAwaiter().GetResult();
            StringBuilder stb = new StringBuilder();
            foreach (var item in rates)
            {
                stb.AppendLine($"{item.cc} - {item.rate}");
            }
            client.SendTextMessageAsync(message.Chat, stb.ToString());
        }
    }
}
