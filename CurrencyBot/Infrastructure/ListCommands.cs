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
            new StartCommand(),
            new HelloCommand(),
            new HelpCommand(),
            new GetTimeCommand(),
            new GetCurrencyRateCommand(),
            new GetCurrencyRateByDateCommand(),
        };
        public static List<Command> GetAllCommands() => _commands;

    }
}
