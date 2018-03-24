namespace Infrastructure.Configuration
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
