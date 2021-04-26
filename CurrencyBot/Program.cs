using CurrencyBot.Infrastructure;
using CurrencyBot.Infrastructure.Extenstions;
using CurrencyBot.Infrastructure.Services;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace CurrencyBot
{
    class Program
    {
        private const string Token = "1658031216:AAECTX6QX5M0l9WzMJ3U2dFJtz_wz-UOb_4";
        static ITelegramBotClient client;
        static async Task Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            var bot = await client.GetMeAsync();
            Console.WriteLine($"Hello from {bot.FirstName}");
            client.OnMessage += Client_OnMessage;
            client.StartReceiving();
            var bgs = new ScheduleBackgroundService(Token);
            await bgs.StartAsync(new System.Threading.CancellationToken());
            Console.ReadKey();
            client.StopReceiving();
        }
        private static void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Text)
            {
                foreach (var item in ListCommands.GetAllCommands())
                {
                    if (item.TextCommand.CheckCommand(e.Message.Text))
                    {
                        item.Execute(client, e.Message);
                        return;
                    }
                }
            }
            client.SendTextMessageAsync(e.Message.Chat, "Команда не вірна!");
        }
    }
}
