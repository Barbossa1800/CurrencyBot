﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class HelloCommand : Command
    {
        public HelloCommand() : base("/hello", "Даннакома", "Hello Nikita") { }
        public override void Execute(ITelegramBotClient client, Message message)
        {
            client.SendTextMessageAsync(message.Chat, "Oooo, Hello!");
        }
    }
}
