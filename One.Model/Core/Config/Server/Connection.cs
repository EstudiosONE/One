using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Config.Server.Model
{
    public class Connection
    {
        public Server.Connection.Model.One One { get; set; }
        public Server.Connection.Model.Paradise Paradise { get; set; }
        public Server.Connection.Model.Audit Audit { get; set; }
    }
}
