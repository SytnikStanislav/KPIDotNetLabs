namespace Services.Settings
{
    public static class SettingList
    {
        public static SerializationType GetSerializationType { get; set; } = SerializationType.Json;
        public static DataProvider GetDataProvider { get; set; } = DataProvider.SqlDbConnection;
        public static string GetConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }

    public enum SerializationType
    {
        Xml,
        Json,
        DataContract
    }

    public enum DataProvider
    {
        InMemory,
        SqlDbConnection,
        LinqToSql
    }
}
