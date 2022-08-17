using System;
using Teste_tecnico_staffing.Entities.Trades;
using Teste_tecnico_staffing.Handlers;
using Xunit;

namespace Test_tecnico_staffing_tests.Handlers
{
    public class TradeCategoryEvalutatorTests
    {
        [Fact]
        public void Evaluator_must_return_expired()
        {
            DateTime referenceDate = new DateTime(month: 11, day: 12, year: 2020);
            DateTime tradeDate = new DateTime(month: 01, day: 07, year: 2020);
            var trade = new Trade(400000, "Public", tradeDate);

            var result = TradeCategoryEvaluator.Handle(trade, referenceDate);

            Assert.NotEmpty(result);
            Assert.Equal("EXPIRED", result);
        }

        [Fact]
        public void Evaluator_must_return_highrisk()
        {
            DateTime referenceDate = new DateTime(month: 11, day: 12, year: 2020);
            DateTime tradeDate = new DateTime(month: 12, day: 29, year: 2025);
            var trade = new Trade(2000000, "Private", tradeDate);

            var result = TradeCategoryEvaluator.Handle(trade, referenceDate);
            Assert.NotEmpty(result);
            Assert.Equal("HIGHRISK", result);
        }

        [Fact]
        public void Evaluator_must_return_mediumrisk()
        {
            DateTime referenceDate = new DateTime(month: 11, day: 12, year: 2020);
            DateTime tradeDate = new DateTime(month: 01, day: 02, year: 2024);
            var trade = new Trade(5000000, "Public", tradeDate);

            var result = TradeCategoryEvaluator.Handle(trade, referenceDate);

            Assert.NotEmpty(result);
            Assert.Equal("MEDIUMRISK", result);
        }
    }
}
