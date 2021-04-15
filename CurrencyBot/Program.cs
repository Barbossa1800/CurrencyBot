using CurrencyBot.Infrastructure;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace CurrencyBot
{
    class Program
    {
        static ITelegramBotClient client;
        static async Task Main(string[] args)
        {
            client = new TelegramBotClient("1658031216:AAECTX6QX5M0l9WzMJ3U2dFJtz_wz-UOb_4");
            var bot = await client.GetMeAsync();
            Console.WriteLine($"Hello from {bot.FirstName}");
            client.OnMessage += Client_OnMessage;
            client.StartReceiving();
            Console.ReadKey();
            client.StopReceiving();
        }
        private static void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Text)
            {
                foreach (var item in ListCommands.GetAllCommands())
                {
                    if (item.TextCommand.Contains(e.Message.Text))
                    {
                        item.Execute(client, e.Message);
                        break;
                    }
                    client.SendTextMessageAsync(e.Message.Chat, "Дане повідомлення не є командою!"); // !!!выводит то кол. скольк команд.
                }
            }
            
        }
    }
}
