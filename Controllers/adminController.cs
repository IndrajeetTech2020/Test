// Decompiled with JetBrains decompiler
// Type: CPJewellery.Controllers.adminController
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using CPJewellery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CPJewellery.Controllers
{
  public class adminController : Controller
  {
    public ActionResult Index() => (ActionResult) this.View();

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult Dashboard() => (ActionResult) this.View();

    public JsonResult Login(Admin _admin)
    {
      Admin admin = new Admin().CheckAdmin(_admin);
      if (!admin.Isadmin)
        return this.Json((object) false, JsonRequestBehavior.AllowGet);
      FormsAuthentication.SetAuthCookie(admin.ID.ToString(), true);
      this.Session["ADMINCODE"] = (object) admin.ID;
      this.Session["ROLE"] = (object) admin.AdminType;
      return this.Json((object) true, JsonRequestBehavior.AllowGet);
    }

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult AddCategory1() => (ActionResult) this.View();

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult AddCategory2() => (ActionResult) this.View();

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult AddCategory3() => (ActionResult) this.View();

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult AddCategory4() => (ActionResult) this.View();

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult Createbill() => (ActionResult) this.View();

    public JsonResult getitems(int _categoryID) => this.Json((object) new Item().GetItembyCategoryID(_categoryID), JsonRequestBehavior.AllowGet);

    public JsonResult getitemdetails(int _itemid) => this.Json((object) new Item().GetItembyItemID(_itemid), JsonRequestBehavior.AllowGet);

    public JsonResult saveinvoice(List<Item> arritems) => this.Json((object) new Item().SaveInvoice(arritems, Convert.ToInt32(this.Session["ADMINCODE"])), JsonRequestBehavior.AllowGet);

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult Billprint() => (ActionResult) this.View();

    public JsonResult GetinvoicebyID(int invoiceno) => this.Json((object) new Item().InvoicebyID(invoiceno), JsonRequestBehavior.AllowGet);

    public JsonResult GetnoninvoicebyID(int invoiceno) => this.Json((object) new Item().NonInvoicebyID(invoiceno), JsonRequestBehavior.AllowGet);

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult AddProducts() => (ActionResult) this.View();

    [HttpPost]
    public ActionResult UploadFiles(FormCollection fileData)
    {
      Item obj1 = new Item();
      obj1.ItemName = fileData["ItemName"];
      obj1.ItemDescription = fileData["ItemDescription"];
      obj1.Qty = Convert.ToInt32(fileData["Qty"]);
      obj1.MetalType = fileData["MetalType"];
      obj1.Caret = Convert.ToInt32(fileData["Caret"]);
      obj1.Weight = Convert.ToDecimal(fileData["Weight"]);
      obj1.Size = fileData["Size"];
      obj1.Color = fileData["Color"];
      obj1.Width = fileData["Width"];
      obj1.Height = fileData["Height"];
      obj1.MakingCharges = Convert.ToDecimal(fileData["MakingCharges"]);
      obj1.CategoryID = Convert.ToInt32(fileData["CategoryID"]);
      this.Server.MapPath("~/ItemPics/");
      List<string> itemimages = new List<string>();
      HttpFileCollectionBase files = this.Request.Files;
      for (int index = 0; index < files.Count; ++index)
      {
        HttpPostedFileBase httpPostedFileBase = files[index];
        string str1 = DateTime.Now.GetHashCode().ToString("x");
        string str2 = Guid.NewGuid().ToString();
        string str3 = str1.Substring(1, str1.Length - 1) + str2;
        string lower = Path.GetExtension(httpPostedFileBase.FileName).ToLower();
        httpPostedFileBase.SaveAs(this.Server.MapPath("~/ItemPics/" + str3 + lower));
        itemimages.Add(str3 + lower);
      }
      Item obj2 = obj1;
      return (ActionResult) this.Json((object) obj2.Save(obj2, itemimages));
    }

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult Purchase() => (ActionResult) this.View();

    public JsonResult savepurchase(List<Item> arritems) => this.Json((object) new Item().SavePurchase(arritems, Convert.ToInt32(this.Session["ADMINCODE"])), JsonRequestBehavior.AllowGet);

    [AuthorizeUser(new string[] {"ADMIN", "USER"})]
    public ActionResult Settings() => (ActionResult) this.View();

    public JsonResult Getsettings() => this.Json((object) new MetalRate().GetRates(), JsonRequestBehavior.AllowGet);

    public JsonResult Updatesettings(MetalRate _metalrate) => this.Json((object) new MetalRate().UpdateRates(_metalrate), JsonRequestBehavior.AllowGet);

    [AuthorizeUser(new string[] {"ADMIN"})]
    public ActionResult Users() => (ActionResult) this.View();

    public JsonResult saveuser(User _user) => this.Json((object) new User().saveuser(_user), JsonRequestBehavior.AllowGet);
  }
}
