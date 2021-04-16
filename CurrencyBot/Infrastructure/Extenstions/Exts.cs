using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyBot.Infrastructure.Extenstions
{
    public static class Exts
    {
        private static char[] delimiters = { '.', ' ', ',', '-', '_' };

        public static char[] Delimiters => delimiters;

        public static bool CheckCommand(this string command, string text)
        {
            if (text.StartsWith(command))
            {
                if (command == text.Split(delimiters)[0])
                    return true;
                return false;
            }
            return false;
        }
    }
}
