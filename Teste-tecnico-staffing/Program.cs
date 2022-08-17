using System;
using System.Collections.Generic;
using System.Globalization;
using Teste_tecnico_staffing.Handlers;
using Teste_tecnico_staffing.Interface;
using System.Linq;
using Teste_tecnico_staffing.Utils;

namespace Teste_tecnico_staffing
{
    public class Program
    {
        static void Main(string[] args)
        {
            var referenceDateString = Console.ReadLine();
            var referenceDate = DateTime.ParseExact(referenceDateString, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);

            var numberOfTradesString = Console.ReadLine();
            int numberOfTrades = int.Parse(numberOfTradesString);

            List<ITrade> tradeList = new List<ITrade>();

            for (int countOfTrades = 0; countOfTrades < numberOfTrades; countOfTrades++)
            {
                var tradeInfo = Console.ReadLine();
                var trade = StringToTradeConverter.Convert(tradeInfo);
                tradeList.Add(trade);
            }

            tradeList.ForEach(trade => Console.WriteLine( TradeCategoryEvaluator.Handle(trade, referenceDate)));
        }
    }
}
