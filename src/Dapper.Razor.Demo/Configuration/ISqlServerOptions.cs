namespace Dapper.Razor.Demo.Configuration
{
    public interface ISqlServerOptions
    {
        string SqlServerConnection { get; set; }

        string ProductsTableName { get; set; }
    }
}
