using System.Configuration;

namespace Voorbereiding_ExamenJan.Data
{
    public static class DatabaseConnection
    {
        public static string Connectionstring(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
