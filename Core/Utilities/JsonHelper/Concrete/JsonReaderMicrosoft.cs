using Core.Utilities.JsonHelper.Abstract;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.JsonHelper.Concrete
{
    public class JsonReaderMicrosoft : IJsonReader
    {

        public string Reader(string? jsonPath, string jsonFile, string jsonKey)
        {
            IConfigurationBuilder configuration = new ConfigurationBuilder();
            configuration.SetBasePath(jsonPath);

            if (jsonPath == null)
                configuration.SetBasePath(Directory.GetCurrentDirectory());

            configuration.AddJsonFile(jsonFile);

            IConfigurationRoot config = configuration.Build();
            return config[jsonKey];
        }
        public string Reader(string jsonFile, string jsonKey)
        {
            IConfigurationBuilder configuration = new ConfigurationBuilder();

            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile(jsonFile);

            IConfigurationRoot config = configuration.Build();
            return config[jsonKey];
        }
    }
}
