using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public class Constants
    {
        #region General
            public const string CONTENT_TYPE_JSON = "application/json";
        #endregion

        #region Exceptions
            public const string EXCEPTION_TITLE = "[Exception]";
            public const string INVALID_TOKEN = "Invalid Token";
            public const string SANITIZED_EXCEPTION = "Ha ocurrido un error con el siguiente codigo de error: {0}. Para mas detalles consulte con el administrador.";
            public const string AUDIT_EXCEPTION = "Error en la auditoria.";
            public const string AUDIT_EXCEPTION_MORE_THAN_ONE_ATTR = "Only one AuditableAttribute can be defined";
            public const string AUDIT_EXCEPTION_NO_ATTR = "An AuditableAttribute should be defined";
            public const string WCF_FAULT_CODE = "WCFServiceException";
        #endregion

        #region Localization
            public const string LOCALIZACION_LENGUAJE_DEFECTO = "es-ES";
            public const string LOCALIZACION_COOKIE = ".AspNetCore.Culture";
        #endregion
    }
}
