using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementation
{
    public class StartCommand : Command
    {
        public StartCommand() : base("/start", "", "") { }

        public override void Execute(ITelegramBotClient client, Message message)
        {
            var commands = Commands.AllCommands;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Привіт!");
            sb.AppendLine("Я підтримую наступні команди:");
            foreach (var command in commands)
            {
                sb.AppendLine($"{command.TextCommand} {command.Des} [{command.Example}]");
            }
            client.SendTextMessageAsync(message.Chat, sb.ToString());
        }
    }
}
