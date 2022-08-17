using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_tecnico_staffing.Entities.Categories;
using Teste_tecnico_staffing.Interface;

namespace Teste_tecnico_staffing.Handlers
{
    public class MediumriskCategoryHandler : BaseCategoryHandler
    {

        public override BaseCategory Category { get; }

        public MediumriskCategoryHandler()
        {
            Category = new MediumRiskCategory();
        }

        public override bool CategoryRule(ITrade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector.ToUpper() == "PUBLIC")
            {
                return true;
            }

            return false;
        }
    }
}
