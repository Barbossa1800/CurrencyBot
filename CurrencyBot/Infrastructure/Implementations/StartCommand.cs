using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class StartCommand : Command
    {
        public StartCommand() : base("/start", "Команда використовується для початку роботи з ботом",  "/start") { }

        public override void Execute(ITelegramBotClient client, Message message)
        {
            client.SendTextMessageAsync(message.Chat, $"Привіт, {message.From.FirstName}!!!\nДля команд: /commands");
        }
    }
}
