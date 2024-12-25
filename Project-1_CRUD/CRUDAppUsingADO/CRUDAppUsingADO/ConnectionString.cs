namespace CRUDAppUsingADO
{
    public  static class ConnectionString
    {
        private static string cs = "Server=(localdb)\\mssqllocaldb; Database=CrudADOdb; Trusted_Connection=True;";

        public static string dbcs { get => cs; }
    }
}
