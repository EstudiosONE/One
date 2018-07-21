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


            return true;
        }
        #endregion



        public struct 
    }
}
