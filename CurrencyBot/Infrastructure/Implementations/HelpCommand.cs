using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class HelpCommand : Command
    {
        public HelpCommand() : base("/help", "Команда надає допомгу користувачу у питаннях", "/help") { }

        public override void Execute(ITelegramBotClient client, Message message)
        {
            client.SendTextMessageAsync(message.Chat, "Що вам конректно портібно?");
        }
    }
}
