namespace Custom.Configuration.Provider.Demo.Configuration
{
    public class SqlServerOptions : ISqlServerOptions
    {
        public string SqlServerConnection { get; set; }
        
        public string ProductsTableName { get; set; }
    }
}
