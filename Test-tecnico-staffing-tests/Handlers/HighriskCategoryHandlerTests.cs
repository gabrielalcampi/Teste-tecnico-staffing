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
    public class HighriskCategoryHandlerTests
    {
        [Fact]
        public void Category_rule_must_return_true()
        {
            DateTime tradeDate = new DateTime(month: 12, day: 29, year: 2025);
            var trade = new Trade(2000000, "Private", tradeDate);

            var handler = new HighriskCategoryHandler();
            var result = handler.CategoryRule(trade);

            Assert.True(result);
        }

        [Fact]
        public void Category_rule_must_return_false()
        {
            DateTime tradeDate = new DateTime(month: 12, day: 29, year: 2025);
            var trade = new Trade(20000, "Private", tradeDate);

            var handler = new HighriskCategoryHandler();
            var result = handler.CategoryRule(trade);

            Assert.False(result);
        }

        [Fact]
        public void Evaluate_Rules_must_return_empty_string()
        {
            DateTime tradeDate = new DateTime(month: 12, day: 29, year: 2025);
            var trade = new Trade(20000, "Private", tradeDate);

            var handler = new HighriskCategoryHandler();
            var result = handler.EvaluateRules(trade);

            Assert.Empty(result);
        }

        [Fact]
        public void Evaluate_Rules_must_return_category_name()
        {
            DateTime tradeDate = new DateTime(month: 12, day: 29, year: 2025);
            var trade = new Trade(2000000, "Private", tradeDate);

            var handler = new HighriskCategoryHandler();
            var result = handler.EvaluateRules(trade);

            Assert.NotEmpty(result);
            Assert.Equal("HIGHRISK", result);
        }
    }
}
