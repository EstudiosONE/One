using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using One.Core;
using One.Model;
using Auth = One.Model.Auth;

namespace One.Installer.DataBase.SQL
{
    class Program
    {
        internal static Model.Core Core = default(Model.Core);

        static void Main(string[] args)
        {
            var initialize = new Initialize();
            initialize.ProgressEvent += Initialize_ProgressEvent;
            Core = initialize.StartAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        private static void Initialize_ProgressEvent(object sender, Initialize.ProgressEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("INICIALIZANDO EL CORE DEL SISTEMA...");
            Console.WriteLine($"Se completaron {e.CompletedTask} de {e.TotalTask} tareas.");
        }
    }
}
