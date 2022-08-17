using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_tecnico_staffing.Entities.Trades;
using Teste_tecnico_staffing.Handlers;
using Xunit;

namespace Test_tecnico_staffing_tests.Handlers
{
    public class MediumriskCategoryHandlerTests
    {
        [Fact]
        public void Category_rule_must_return_true()
        {
            DateTime tradeDate = new DateTime(month: 01, day: 02, year: 2024);
            var trade = new Trade(5000000, "Public", tradeDate);

            var handler = new MediumriskCategoryHandler();
            var result = handler.CategoryRule(trade);

            Assert.True(result);
        }

        [Fact]
        public void Category_rule_must_return_false()
        {
            DateTime tradeDate = new DateTime(month: 01, day: 02, year: 2024);
            var trade = new Trade(5000, "Public", tradeDate);

            var handler = new MediumriskCategoryHandler();
            var result = handler.CategoryRule(trade);

            Assert.False(result);
        }

        [Fact]
        public void Evaluate_Rules_must_return_empty_string()
        {
            DateTime tradeDate = new DateTime(month: 01, day: 02, year: 2024);
            var trade = new Trade(5000, "Public", tradeDate);

            var handler = new MediumriskCategoryHandler();
            var result = handler.EvaluateRules(trade);

            Assert.Empty(result);
        }

        [Fact]
        public void Evaluate_Rules_must_return_category_name()
        {
            DateTime tradeDate = new DateTime(month: 01, day: 02, year: 2024);
            var trade = new Trade(5000000, "Public", tradeDate);

            var handler = new MediumriskCategoryHandler();
            var result = handler.EvaluateRules(trade);

            Assert.NotEmpty(result);
            Assert.Equal("MEDIUMRISK", result);
        }
    }
}
