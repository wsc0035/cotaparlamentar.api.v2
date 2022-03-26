namespace cotaparlamentar.api.v2.Infraestructure
{
    public static class ConfigAppSettings
    {
        public static string Legislatura { get; private set; }
        public static string UrlApi { get; private set; }

        static ConfigAppSettings()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();        
            Legislatura = root.GetValue<string>("Legislatura").ToString();
            UrlApi = root.GetValue<string>("ApiUrl").ToString();
        }
    }
}
