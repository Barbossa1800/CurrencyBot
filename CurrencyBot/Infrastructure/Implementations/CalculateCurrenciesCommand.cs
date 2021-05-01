using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyBot.Infrastructure.Implementations
{
    public class CalculateCurrenciesCommand : Command
    {
        public CalculateCurrenciesCommand() : base("/calcCurrency", " Дана команда дає можливість розрахувати відношення валют" +
            " одна до одної." +
            "\nДля запису валют - використовуйте приблизно вірне найменнувая.", "/calcCurrency США Лей 300") { }

        public override void Execute(ITelegramBotClient client, Message message)
        {
            try
            {
                var rates = NBU.GetRatesAsync().Result;
                var parts = message.Text.Split(' ');
                var fromName = parts[1];
                var fromCurrency = rates.FirstOrDefault(d => d.Text.ToLower().Contains(fromName));
                var toName = parts[2];
                var toCurrency = rates.FirstOrDefault(d => d.Text.ToLower().Contains(toName));
                var sum = Convert.ToDouble(parts[3]);
                if (fromCurrency == null || toCurrency == null)
                {
                    client.SendTextMessageAsync(message.Chat, "Одна з вказаної вами валют не знайдено!");
                    return;
                }
                var firstSum = sum * fromCurrency.Rate;
                var secondSum = Math.Round(firstSum / toCurrency.Rate, 2);
                client.SendTextMessageAsync(message.Chat, $"Якщо первести {sum} з {fromCurrency.Text} в {toCurrency.Text}, то буде {secondSum}");
            }
            catch (Exception ex)
            {
                client.SendTextMessageAsync(message.Chat, $"{ex.Message}");
            }
        }
    }
}
