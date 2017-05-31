namespace CodErator
{
    class SQLConnectHelper
    {
        private static readonly SQLConnectHelper instance = null; /* 单例设计 */
        private string ip;
        private uint port;
        private string user;
        private string pass;
        private string database;

        static SQLConnectHelper()
        {
            instance = new SQLConnectHelper();
        }

        private SQLConnectHelper()
        {
        }

        public static SQLConnectHelper Instance
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
        public string Database
        {
            get => database;
            set => database = value.ToLower();
        }
        /*
         * sql connecting string
         * server=IP;port=port;User ID=username;Password=password;database=schema_name;
         */
    }
}
