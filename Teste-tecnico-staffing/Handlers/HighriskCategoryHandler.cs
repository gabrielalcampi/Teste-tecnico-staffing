using System;
using Teste_tecnico_staffing.Entities.Categories;
using Teste_tecnico_staffing.Interface;

namespace Teste_tecnico_staffing.Handlers
{
    public class HighriskCategoryHandler : BaseCategoryHandler
    {

        public override BaseCategory Category { get; }

        public HighriskCategoryHandler()
        {
            Category = new HighRiskCategory();
        }

        public override bool CategoryRule(ITrade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector.ToUpper() == "PRIVATE")
            {
                return true;
            }

            return false;
        }
    }
}
