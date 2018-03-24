using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseArchitecture
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
