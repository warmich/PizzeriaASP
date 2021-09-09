using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pizzeria.ASP.Security
{
	public class CustomAuthorisationAttribute : Attribute, IAuthorizationFilter
	{
		private readonly string[] _roles;

		public CustomAuthorisationAttribute(params string[] roles)
		{
			_roles = roles;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			string role = context.HttpContext.Session.GetString("Role");
			if (!_roles.Contains(role))
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
