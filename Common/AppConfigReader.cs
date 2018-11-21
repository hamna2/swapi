using System.Configuration;
using SwapiApiChallenge.Interfaces;

namespace SwapiApiChallenge.Common
{
    public class AppConfigReader :IAppConfigReader
    {
        
        public string GetApiUrl()
        {
            return ConfigurationManager.AppSettings["Url"];
        }
    }
}