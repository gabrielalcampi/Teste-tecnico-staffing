using System;
using System.Globalization;
using Teste_tecnico_staffing.Entities.Trades;

namespace Teste_tecnico_staffing.Utils
{
    public static class StringToTradeConverter
    {
        public static Trade Convert(string inputString)
        {
            var trim = inputString.Split(' ', 3, System.StringSplitOptions.TrimEntries);
            var value = int.Parse(trim[0]);
            var sector = trim[1];
            var date = DateTime.ParseExact(trim[2], "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

            return new Trade(value, sector, date);
        }
    }
}
