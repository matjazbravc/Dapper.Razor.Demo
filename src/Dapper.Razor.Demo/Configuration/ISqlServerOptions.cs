﻿namespace Custom.Configuration.Provider.Demo.Configuration
{
    public interface ISqlServerOptions
    {
        string SqlServerConnection { get; set; }

        string ProductsTableName { get; set; }
    }
}
