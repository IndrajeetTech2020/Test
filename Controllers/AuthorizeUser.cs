// Decompiled with JetBrains decompiler
// Type: CPJewellery.Controllers.AuthorizeUser
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CPJewellery.Controllers
{
  public class AuthorizeUser : AuthorizeAttribute
  {
        private string[] allowedroles;

        public AuthorizeUser(params string[] roles)
        {
            this.allowedroles = roles;
        }
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //  bool flag = false;
        //  try
        //  {
        //    foreach (string allowedrole in this.allowedroles)
        //    {
        //      if (httpContext.Session["ROLE"].ToString().Contains(allowedrole))
        //        flag = true;
        //    }
        //  }
        //  catch
        //  {
        //  }
        //  return flag;
        //}

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) => filterContext.Result = (ActionResult) new RedirectToRouteResult(new RouteValueDictionary((object) new
        {
          controller = "Misc",
          action = "Unauthorised"
        }));
    }
}
