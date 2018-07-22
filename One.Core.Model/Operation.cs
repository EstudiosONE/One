using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Operation.Model
{
    public struct Operation
    {
        private readonly short
       _module,
       _subModule,
       _operation,
       _subOperation;

        public Operation(short module, short subModule, short operation, short subOperation)
        {
            _module = module;
            _subModule = subModule;
            _operation = operation;
            _subOperation = subOperation;
        }

        public override string ToString()
        {
            return $"{_module.ToString("0000")}.{_subModule.ToString("0000")}.{_operation.ToString("0000")}.{_subOperation.ToString("0000")}";
        }

        public class Names
        {
            public static class Hotel
            {
                internal static short Current => 0100;

                public static class Reservation
                {
                    internal static short Current => 0001;

                    public static Operation New => new Operation(Hotel.Current, Reservation.Current, 0500, 0000);
                }
            }
            public static class Management
            {
                internal static short Current => 0050;

                public class Report
                {
                    internal static short Current => 0010;

                    public class Inventory
                    {
                        internal static short Current => 0010;

                        #region Get Stock
                        public static Operation GetStock_Screen => new Operation(Management.Current, Report.Current, Inventory.Current, 0011);
                        public static Operation GetStock_PDF => new Operation(Management.Current, Report.Current, Inventory.Current, 0011);
                        public static Operation GetStock_Excel => new Operation(Management.Current, Report.Current, Inventory.Current, 0011);
                        #endregion

                        #region Get Sale Items
                        public static Operation GetSaleItems_Screen => new Operation(Management.Current, Report.Current, Inventory.Current, 0021);
                        public static Operation GetSaleItems_PDF => new Operation(Management.Current, Report.Current, Inventory.Current, 0022);
                        public static Operation GetSaleItems_Excel => new Operation(Management.Current, Report.Current, Inventory.Current, 0023);
                        #endregion
                    }
                }
            }
        }
    }

}
