using SwapiApiChallenge.Common;
using SwapiApiChallenge.Interfaces;
using Xunit;

namespace Swapi.UnitTests
{
    public class AppConfigReaderUnitTests
    {
        [Fact]
        public void AppConfigReader_Exists()
        {
            IAppConfigReader configReader =new AppConfigReader();
            Assert.NotNull(configReader);
        }
        
    }
}
