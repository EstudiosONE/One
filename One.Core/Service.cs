using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core
{
    public class Service
    {
        #region Variables Estaticas
        static Service current;
        #endregion

        #region Propiedades Estaticas
        public static Service Current { get; }
        #endregion

        #region Variables

        #endregion

        #region Propiedades
        #endregion

        #region Constructores
        public Service()
        {
            current = this;
        }
        #endregion

        #region Metodos
        #region Privados
        #endregion

        #region Internos
        #endregion

        #region Publicos
        #endregion
        #endregion
    }
}
