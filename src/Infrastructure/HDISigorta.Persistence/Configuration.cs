using Microsoft.Extensions.Configuration;

namespace HDISigorta.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                // Json dosyalarını hızlı bir şekilde okuyabilmek için tanımladık.
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../HDISigorta.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
