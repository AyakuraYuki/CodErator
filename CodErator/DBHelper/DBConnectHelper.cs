namespace CodErator.DBHelper
{
    class DBConnectHelper
    {
        private static readonly DBConnectHelper instance = null; /* 单例设计 */
        private string ip;
        private uint port;
        private string user;
        private string pass;
        private string schema;

        static DBConnectHelper()
        {
            instance = new DBConnectHelper();
        }

        private DBConnectHelper()
        {
        }

        public static DBConnectHelper Instance
        {
            get => instance;
        }

        public string IP
        {
            get => ip;
            set => ip = value;
        }
        public uint Port
        {
            get => port;
            set => port = value;
        }
        public string User
        {
            get => user;
            set => user = value;
        }
        public string Pass
        {
            get => pass;
            set => pass = value;
        }
        public string Schema
        {
            get => schema;
            set => schema = value.ToLower();
        }
        /*
         * sql connecting string
         * server=IP;port=port;User ID=username;Password=password;database=schema_name;
         */
    }
}
