using System;
using System.Collections.Generic;
using System.Text;

namespace One.Core.Auth.Model
{
    public interface IToken
    {
        #region Propiedades
        #endregion

        #region Metodos
        /// <summary>
        /// Valida el token y verifica que exista autorización para realizar la operación solicitada.
        /// </summary>
        /// <param name="request">Solicitud HTTP recibida en la petición.</param>
        /// <param name="operation">Solicitud HTTP recibida en la petición.</param>
        /// <returns></returns>
        bool Validation(System.Net.Http.HttpRequestMessage request, string operation);
        #endregion
    }
}
