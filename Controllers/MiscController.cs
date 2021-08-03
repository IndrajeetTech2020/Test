// Decompiled with JetBrains decompiler
// Type: CPJewellery.Controllers.MiscController
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System.Web.Mvc;

namespace CPJewellery.Controllers
{
  public class MiscController : Controller
  {
    public ActionResult Login() => (ActionResult) this.View();

    public ActionResult Logout()
    {
      this.Session.Abandon();
      return (ActionResult) this.RedirectToAction("Index", "admin");
    }

    public ActionResult Unauthorised() => (ActionResult) this.View();
  }
}
