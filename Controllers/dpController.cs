// Decompiled with JetBrains decompiler
// Type: CPJewellery.Controllers.dpController
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using CPJewellery.Models;
using Microsoft.CSharp.RuntimeBinder;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CPJewellery.Controllers
{
  public class dpController : Controller
  {
    private Category category = new Category();

    public ActionResult Index()
    {
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = dpController.Target((CallSite) dpController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public ActionResult Products(int id)
    {
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = dpController.Target((CallSite) dpController, this.ViewBag, this.GetAllCategoriesForTree());
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "CategoryID", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = dpController.Target((CallSite) dpController, this.ViewBag, id);
      return (ActionResult) this.View();
    }

    public JsonResult GetProducts(int categoryid) => this.Json((object) new Item().GetProductsbyCategoryID(categoryid), JsonRequestBehavior.AllowGet);

    public ActionResult Proddetails(int ID)
    {
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = dpController.Target((CallSite) dpController, this.ViewBag, this.GetAllCategoriesForTree());
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, int, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ItemID", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = dpController.Target((CallSite) dpController, this.ViewBag, ID);
      return (ActionResult) this.View((object) new Item().GetItembyItemID(ID));
    }

    public JsonResult GetImagesbyItemID(int itemID) => this.Json((object) new Item().GetItemImagesbyItemID(itemID), JsonRequestBehavior.AllowGet);

    public JsonResult getrelatedproducts(int itemID) => this.Json((object) new Item().GetRelatedItemsbyItemID(itemID), JsonRequestBehavior.AllowGet);

    public ActionResult Checkout()
    {
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = dpController.Target((CallSite) dpController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public JsonResult savetransaction(List<Item> arritems)
    {
      Item obj = new Item().SaveTransaction(arritems);
      PaymentInitiateModel paymentInitiateModel = new PaymentInitiateModel();
      this.Session["transactionid"] = (object) obj.TransactionID;
      this.Session["amt"] = (object) obj.InvoiceAmt;
      return this.Json((object) obj, JsonRequestBehavior.AllowGet);
    }

    public ActionResult PaymentDetails() => (ActionResult) this.View();

    public JsonResult GetOtp() => this.Json((object) "6666", JsonRequestBehavior.AllowGet);

    [HttpPost]
    public ActionResult CreateOrder(PaymentInitiateModel _requestData)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      string str1 = new Random().Next(10000000, 100000000).ToString();
      Order order = new RazorpayClient("rzp_test_VtZ4RepSKRLhhF", "aNlF7C7Onl9FbxuoHQfh22jo").Order.Create(new Dictionary<string, object>()
      {
        {
          "amount",
          (object) (Convert.ToInt32(this.Session["amt"]) * 100)
        },
        {
          "receipt",
          (object) str1
        },
        {
          "currency",
          (object) "INR"
        },
        {
          "payment_capture",
          (object) "0"
        }
      });
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (dpController)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string> target1 = dpController.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string>> p1 = dpController;
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<Type>) null, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = dpController.Target((CallSite) dpController, order["id"]);
      string orderno = target1((CallSite) p1, obj1);
      dpController.OrderModel orderModel1 = new dpController.OrderModel();
      dpController.OrderModel orderModel2 = orderModel1;
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (dpController)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string> target2 = dpController.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string>> p3 = dpController;
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = dpController.Target((CallSite) dpController, order.Attributes, "id");
      string str2 = target2((CallSite) p3, obj2);
      orderModel2.orderId = str2;
      orderModel1.razorpayKey = "rzp_test_VtZ4RepSKRLhhF";
      orderModel1.amount = Convert.ToInt32(this.Session["amt"]) * 100;
      orderModel1.currency = "INR";
      orderModel1.name = _requestData.name;
      orderModel1.email = _requestData.email;
      orderModel1.contactNumber = _requestData.contactNumber;
      orderModel1.address = _requestData.address;
      orderModel1.description = "CP Jewellery";
      dpController.OrderModel orderModel3 = orderModel1;
      this.Session["contact"] = (object) _requestData.contactNumber;
      new Item().updatetransaction(_requestData, orderno, this.Session["transactionid"].ToString());
      return (ActionResult) this.View("PaymentProcess", (object) orderModel3);
    }

    [HttpPost]
    public ActionResult Complete()
    {
      string str1 = this.Request.Params["rzp_paymentid"];
      string orderno = this.Request.Params["rzp_orderid"];
      Payment payment1 = new RazorpayClient("rzp_test_VtZ4RepSKRLhhF", "aNlF7C7Onl9FbxuoHQfh22jo").Payment.Fetch(str1);
      Dictionary<string, object> attributes = new Dictionary<string, object>();
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Action<CallSite, Dictionary<string, object>, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Action<CallSite, Dictionary<string, object>, string, object> target1 = dpController.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Action<CallSite, Dictionary<string, object>, string, object>> p1 = dpController;
      Dictionary<string, object> dictionary = attributes;
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = dpController.Target((CallSite) dpController, payment1.Attributes, "amount");
      target1((CallSite) p1, dictionary, "amount", obj1);
      Payment payment2 = payment1.Capture(attributes);
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (dpController)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string> target2 = dpController.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string>> p3 = dpController;
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = dpController.Target((CallSite) dpController, payment2.Attributes, "amount");
      string str2 = target2((CallSite) p3, obj2);
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, bool> target3 = dpController;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, bool>> p6 = dpController;
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string, object> target4 = dpController;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string, object>> p5 = dpController;
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = dpController.Target((CallSite) dpController, payment2.Attributes, "status");
      object obj4 = target4((CallSite) p5, obj3, "captured");
      if (!target3((CallSite) p6, obj4))
        return (ActionResult) this.RedirectToAction("Failed");
      new Item().updatetransactionstatus(orderno, str1);
      return (ActionResult) this.RedirectToAction("Success");
    }

    public ActionResult Success()
    {
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = dpController.Target((CallSite) dpController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public ActionResult Failed()
    {
      // ISSUE: reference to a compiler-generated field
      if (dpController == null)
      {
        // ISSUE: reference to a compiler-generated field
        dpController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (dpController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = dpController.Target((CallSite) dpController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public string GetAllCategoriesForTree()
    {
      List<Category> flatObjects = new List<Category>();
      DataTable dataTable = this.category.getcategories();
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return "Categories Empty!";
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        flatObjects.Add(new Category()
        {
          CategoryId = Convert.ToInt32(row["CategoryId"]),
          CategoryName = row["CategoryName"].ToString(),
          ParentCategoryId = Convert.ToInt32(row["ParentCategoryId"]) != 0 ? new int?(Convert.ToInt32(row["ParentCategoryId"])) : new int?()
        });
      List<TreeNode> treeNodeList = dpController.FillRecursive(flatObjects);
      string str = string.Empty;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      foreach (TreeNode treeNode in treeNodeList)
      {
        str = str + "<li class=\"grid\"><a class=\"color1\" href=\"#\">" + treeNode.CategoryName + "</a>";
        str += "<div class=\"megapanel\" style=\"display: none; opacity: 1 ;\">";
        str += "<div class=\"row\">";
        foreach (TreeNode child1 in treeNode.Children)
        {
          str += "<div class=\"col1\">";
          str += "<div class=\"h_nav\">";
          str = str + "<h4>" + child1.CategoryName + "</h4>";
          str += "<ul>";
          foreach (TreeNode child2 in child1.Children)
            str = str + "<li><a href='/dp/Products/" + (object) child2.CategoryId + "'>" + child2.CategoryName + "</a></li>";
          str += "</ul>";
          str += "</div>";
          str += "</div>";
        }
        str += "</div>";
        str += "</div>";
        str += "</li>";
      }
      return str;
    }

    private static List<TreeNode> FillRecursive(
      List<Category> flatObjects,
      int? parentId = null)
    {
      return flatObjects.Where<Category>((Func<Category, bool>) (x => x.ParentCategoryId.Equals((object) parentId))).Select<Category, TreeNode>((Func<Category, TreeNode>) (item => new TreeNode()
      {
        CategoryName = item.CategoryName,
        CategoryId = item.CategoryId,
        Children = dpController.FillRecursive(flatObjects, new int?(item.CategoryId))
      })).ToList<TreeNode>();
    }

    public class OrderModel
    {
      public string orderId { get; set; }

      public string razorpayKey { get; set; }

      public int amount { get; set; }

      public string currency { get; set; }

      public string name { get; set; }

      public string email { get; set; }

      public string contactNumber { get; set; }

      public string address { get; set; }

      public string description { get; set; }
    }
  }
}
