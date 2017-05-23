using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodErator
{
    class SQLConnectHelper
    {
        private static string ip;
        private static int port;
        private static string user;
        private static string pass;
        private static string database;

        public static string IP
        {
            get => ip;
            set => ip = value;
        }
        public static int Port
        {
            get => port;
            set => port = value;
        }
        public static string User
        {
            get => user;
            set => user = value;
        }
        public static string Pass
        {
            get => pass;
            set => pass = value;
        }
        public static string Database
        {
            get => database;
            set => database = value.ToLower();
        }
        /*
         * sql connecting string
         * server=localhost;user id=root;password=root;persistsecurityinfo=True;database=studentstate
         */
    }
}
