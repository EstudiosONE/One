using One.Core.Model.Storage.One.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using One.Core.Model.Storage.One;
using One.Core.Model.Storage.One.Service.Auth;
using One.Core.Auth.Model;

namespace One.Core.Storage.One
{
    public class Service : Model.Storage.One.IService
    {
        public Service()
        {
            Auth = new Auth();
        }

        public IAuth Auth { get; }
    }

    public class Auth : IAuth
    {
        public Auth()
        {
            Token = new Token();
        }

        public Model.Storage.One.Service.Auth.IToken Token { get; }
    }

    public class Token : Model.Storage.One.Service.Auth.IToken
    {
        public bool Create<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public bool Read(string id, out Core.Auth.Model.IToken token)
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(T instance)
        {
            throw new NotImplementedException();
        }
    }
}
