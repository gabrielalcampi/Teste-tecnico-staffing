using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_tecnico_staffing.Utils;
using Xunit;

namespace Test_tecnico_staffing_tests.Utils
{
    public class StringToTradeConverterTests
    {
        [Fact]
        public void Must_Parse_correctly() 
        {
            string originalInput = "2000000 Private 12/29/2025";

            var result = StringToTradeConverter.Convert(originalInput);

            double expectedValue = 2000000;
            string expectedSector = "Private";
            DateTime expectedDate = new DateTime(month:12, day: 29,year:2025);

            Assert.NotNull(result);
            Assert.NotEmpty(result.ClientSector);
            Assert.Equal(expectedValue,result.Value);
            Assert.Equal(expectedSector,result.ClientSector);
            Assert.Equal(expectedDate,result.NextPaymentDate);
        }      
    }
}
