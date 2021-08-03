// Decompiled with JetBrains decompiler
// Type: CPJewellery.MvcApplication
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CPJewellery
{
  public class MvcApplication : HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}
