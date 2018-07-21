using One.Core.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Auth
{
    public class Service
    {
        Token token;

        public Token Token { get; }

    }

    public class Token : IToken
    {
        #region Metodos

        public bool Validation(System.Net.Http.HttpRequestMessage request, string operation)
        {
            var a = Operation.Hotel.Reservation.New;

            return true;
        }
        #endregion



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

            public static class Hotel
            {
                internal static short Current => 0100;
                
                public static class Reservation
                {
                    internal static short Current => 0001;

                    public static Operation New => new Operation(Hotel.Current, Reservation.Current, 0500, 0000);
                }
            }
        }
    }
}
