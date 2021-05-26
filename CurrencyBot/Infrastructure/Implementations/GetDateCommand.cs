using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class GetDateCommand : Command
    {
        public GetDateCommand() : base("/getDate", "Команда показує поточну дату ", "/getDate") { }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            client.SendTextMessageAsync(message.Chat, $"{DateTime.UtcNow.ToLocalTime().ToLongDateString()}");
        }
    }
}
