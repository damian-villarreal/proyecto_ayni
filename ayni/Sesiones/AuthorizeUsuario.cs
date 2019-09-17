using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayni.Sesiones
{
    public class AuthorizeUsuario : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var esAutorizado = base.AuthorizeCore(httpContext);
            if (!esAutorizado)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}