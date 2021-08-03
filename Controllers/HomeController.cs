// Decompiled with JetBrains decompiler
// Type: CPJewellery.Controllers.HomeController
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using CPJewellery.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CPJewellery.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      // ISSUE: reference to a compiler-generated field
      if (HomeController == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = HomeController.Target((CallSite) HomeController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public ActionResult RefundPolicy()
    {
      // ISSUE: reference to a compiler-generated field
      if (HomeController == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = HomeController.Target((CallSite) HomeController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public ActionResult Contact()
    {
      // ISSUE: reference to a compiler-generated field
      if (HomeController == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = HomeController.Target((CallSite) HomeController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public ActionResult About()
    {
      // ISSUE: reference to a compiler-generated field
      if (HomeController == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = HomeController.Target((CallSite) HomeController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public ActionResult TermsandConditions()
    {
      // ISSUE: reference to a compiler-generated field
      if (HomeController == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = HomeController.Target((CallSite) HomeController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public string GetAllCategoriesForTree()
    {
      List<Category> flatObjects = new List<Category>();
      DataTable dataTable = new Category().getcategories();
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return "Categories Empty!";
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        flatObjects.Add(new Category()
        {
          CategoryId = Convert.ToInt32(row["CategoryId"]),
          CategoryName = row["CategoryName"].ToString(),
          ParentCategoryId = Convert.ToInt32(row["ParentCategoryId"]) != 0 ? new int?(Convert.ToInt32(row["ParentCategoryId"])) : new int?()
        });
      List<TreeNode> treeNodeList = HomeController.FillRecursive(flatObjects);
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
        Children = HomeController.FillRecursive(flatObjects, new int?(item.CategoryId))
      })).ToList<TreeNode>();
    }
  }
}
