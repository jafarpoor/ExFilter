using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FiltersPro.Models.Filters
{
    public class AuthorizeActionFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _Role;

        public AuthorizeActionFilter(string Role)
        {
            _Role = Role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var CheckAuthorize = CheckUserPromission(context.HttpContext.User, _Role);
            if (!CheckAuthorize)
                context.Result = new UnauthorizedResult();
        }

        public bool CheckUserPromission(ClaimsPrincipal user , string role)
        {
            if (role == "Admin")
                return true;
            else
                return false;
        }
    }
}
