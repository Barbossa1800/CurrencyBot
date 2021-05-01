using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class CalculateCommand : Command
    {
        public CalculateCommand() : base("/calc", " Дана команда коневертує вказану кількість валюбти в гривню", "" +
            "/calc США 1") { }

        public override void Execute(ITelegramBotClient client, Message message)
        {
            try
            {
                var rates = NBU.GetRatesAsync().Result;
                var parts = message.Text.Split(' ');
                if (parts.Length <= 1)
                {
                    client.SendTextMessageAsync(message.Chat, "Будь ласка впишіть валюту коректно!");
                    return;
                }
                var currency = rates.FirstOrDefault(d => d.Text.ToLower().Contains(parts[1]));

                client.SendTextMessageAsync(message.Chat, $"Ваш запит на {currency.Text} = {currency.Rate * Convert.ToInt64(parts[2])} гривень");
            }
            catch (Exception ex)
            {

                client.SendTextMessageAsync(message.Chat, $"{ex.Message}");
            }
            
        }
    }
}
