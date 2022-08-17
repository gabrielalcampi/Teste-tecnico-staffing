using System;
using Teste_tecnico_staffing.Entities.Categories;
using Teste_tecnico_staffing.Interface;

namespace Teste_tecnico_staffing.Handlers
{
    public class ExpiredCategoryHandler : BaseCategoryHandler
    {
        public override BaseCategory Category { get; }

        DateTime ReferenceDate;
        public ExpiredCategoryHandler( DateTime referenceDate)
        {
            Category = new ExpiredCategory();

            ReferenceDate = referenceDate;
        }

        public override bool CategoryRule(ITrade trade)
        {
            TimeSpan paymentTimeSpan = (ReferenceDate - trade.NextPaymentDate);

            if (paymentTimeSpan.Days > 30)
            {
                return true;
            }

            return false;
        }
    }
}
