using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyBot.Infrastructure.Implementations;

namespace CurrencyBot.Infrastructure
{
    public class ListCommands
    {

        private static List<Command> _commands /*нотация внутренего элемента*/ = new List<Command>()
        {
            new AllCommand(),
            new StartCommand(),
            //new HelloCommand(), лишняя, есть тстартовая
            new HelpCommand(),
            new GetDateCommand(),
            new GetMainCurrencyCommand(),
            new GetCurrencyRateCommand(),
            new GetCurrencyRateByDateCommand(),
            new CalculateCurrenciesCommand(),
            new CalculateCommand(),
        };
        public static List<Command> GetAllCommands() => _commands;

    }
}
