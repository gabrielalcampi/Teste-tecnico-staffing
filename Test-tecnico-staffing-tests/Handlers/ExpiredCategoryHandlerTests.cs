using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Teste_tecnico_staffing.Handlers;
using Teste_tecnico_staffing.Entities.Trades;

namespace Test_tecnico_staffing_tests.Handlers
{
    public class ExpiredCategoryHandlerTests
    {
        [Fact]
        public void Category_rule_must_return_true()
        {
            DateTime referenceDate = new DateTime(month: 11, day: 12, year: 2020);
            DateTime tradeDate = new DateTime(month: 01, day: 07, year: 2020);
            var trade = new Trade(400000, "Public", tradeDate);

            var handler = new ExpiredCategoryHandler(referenceDate);
            var result = handler.CategoryRule(trade);

            Assert.True(result);
        }

        [Fact]
        public void Category_rule_must_return_false()
        {
            DateTime referenceDate = new DateTime(month: 11, day: 12, year: 2020);
            DateTime tradeDate = new DateTime(month: 11, day: 07, year: 2020);
            var trade = new Trade(400000, "Public", tradeDate);

            var handler = new ExpiredCategoryHandler(referenceDate);
            var result = handler.CategoryRule(trade);

            Assert.False(result);
        }

        [Fact]
        public void Evaluate_Rules_must_return_empty_string()
        {
            DateTime referenceDate = new DateTime(month: 11, day: 12, year: 2020);
            DateTime tradeDate = new DateTime(month: 11, day: 07, year: 2020);
            var trade = new Trade(400000, "Public", tradeDate);

            var handler = new ExpiredCategoryHandler(referenceDate);
            var result = handler.EvaluateRules(trade);

            Assert.Empty(result);
        }

        [Fact]
        public void Evaluate_Rules_must_return_category_name()
        {
            DateTime referenceDate = new DateTime(month: 11, day: 12, year: 2020);
            DateTime tradeDate = new DateTime(month: 01, day: 07, year: 2020);
            var trade = new Trade(400000, "Public", tradeDate);

            var handler = new ExpiredCategoryHandler(referenceDate);
            var result = handler.EvaluateRules(trade);

            Assert.NotEmpty(result);
            Assert.Equal("EXPIRED", result);
        }
    }
}
