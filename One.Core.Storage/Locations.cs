using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Storage
{
    public class Locations
    {
        internal string CommonApplicationData { get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Estudios One", "iGS"); }

        public Server Server { get; }

        public Locations()
        {
            Server = new Server(this);
        }


    }

    public class Server
    {
        private Locations Locations { get; }

        internal Server(Locations locations)
        {
            Locations = locations;
        }

        public string CommonApplicationData { get => Path.Combine(Locations.CommonApplicationData, "Server"); }

    }
}
