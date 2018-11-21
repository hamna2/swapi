using SwapiApiChallenge;
using SwapiApiChallenge.Common;
using SwapiApiChallenge.Exceptions;
using SwapiApiChallenge.Interfaces;
using Xunit;

namespace Swapi.UnitTests
{
    public class ConusmableConverterUnitTests
    {
        [Fact]
        public void ConusmableConverter_Exists()
        {
            IConsumableConverter consumableConverter = new ConusmableConverter();
            Assert.NotNull(consumableConverter);
        }


        [Fact]
        public void ConusmableConverter_WithUnKnownFormat_throwsConsumableFormatNotFound()
        {
            const string consumableStub = "2 Tuple";
            var sut = new ConusmableConverter();

            Assert.Throws<ConsumableFormatNotFoundException>(() => sut.Convert(consumableStub));

        }

        [Fact]
        public void ConusmableConverter_ConversionFails_throwsConsumableConversionExecption()
        {
            const string consumableStub = "abc week";
            var sut = new ConusmableConverter();

            Assert.Throws<ConsumableConversionExecption>(() => sut.Convert(consumableStub));

        }

        
        [Theory]
        [InlineData("2 Weeks",14)]
        [InlineData("4 Months", 120)]
        [InlineData("5 Years", 1825)]
        public void ConusmableConverter_With2Weeks(string value,int expected)
        {
            var sut = new ConusmableConverter();
            var result = sut.Convert(value);

            Assert.Equal(expected, result);
        }
    }
}