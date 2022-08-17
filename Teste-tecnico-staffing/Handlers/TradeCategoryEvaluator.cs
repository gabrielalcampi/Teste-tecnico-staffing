using System;
using System.Collections.Generic;
using Teste_tecnico_staffing.Interface;

namespace Teste_tecnico_staffing.Handlers
{
    public static class TradeCategoryEvaluator
    {
        public static string Handle(ITrade trade, DateTime dateTime)
        {
            List<BaseCategoryHandler> list = new List<BaseCategoryHandler>();

            list.Add(new ExpiredCategoryHandler(dateTime));
            list.Add(new HighriskCategoryHandler());
            list.Add(new MediumriskCategoryHandler());

            return CreateWorkflow(list).EvaluateRules(trade);
        }

        private static BaseCategoryHandler CreateWorkflow(List<BaseCategoryHandler> list)
        {
            var arraylist = list.ToArray();
            for (int i = 0; i < arraylist.Length - 1; i++)
            {
                arraylist[i].SetNextCategoryHandler(arraylist[i + 1]);
            }

            return arraylist[0];
        }
    }
}
