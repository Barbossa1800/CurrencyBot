using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class AllCommand : Command
    {
        public AllCommand() : base("/commands", "Вивід усіх команд", "/commands") { }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            var commands = ListCommands.GetAllCommands();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Я підтримую наступні команди:");
            foreach (var command in commands.Skip(1))
            {
                sb.AppendLine($"{command.TextCommand} {command.Des} \nПриклад: [{command.Example}]\n");
            }
            client.SendTextMessageAsync(message.Chat, sb.ToString());
        }
    }
}
