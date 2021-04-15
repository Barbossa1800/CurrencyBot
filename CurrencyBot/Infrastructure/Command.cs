using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure
{
    public abstract class Command
    {
        public Command(string textCommand, string desc, string example)
        {
            TextCommand = textCommand;
            Des = desc;
            Example = example;
        }
        public Command() { }
        public string Des { get; set; }
        public string Example { get; set; }
        public string TextCommand { get; set; }
        public abstract void Execute(ITelegramBotClient client, Message message);
    }
}
