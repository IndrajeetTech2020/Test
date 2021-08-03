// Decompiled with JetBrains decompiler
// Type: CPJewellery.Controllers.CategoryController
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
  public class CategoryController : Controller
  {
    private Category category = new Category();

    public ActionResult Index()
    {
      // ISSUE: reference to a compiler-generated field
      if (CategoryController == null)
      {
        // ISSUE: reference to a compiler-generated field
        CategoryController = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Tree", typeof (CategoryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = CategoryController.Target((CallSite) CategoryController, this.ViewBag, this.GetAllCategoriesForTree());
      return (ActionResult) this.View();
    }

    public JsonResult GetCategorybyParentCat(int _parent) => this.Json((object) this.category.GetCategorybyParent(_parent), JsonRequestBehavior.AllowGet);

    [HttpPost]
    public JsonResult SaveCategory(Category _category) => this.Json((object) this.category.Save(_category), JsonRequestBehavior.AllowGet);

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
      List<TreeNode> treeNodeList = CategoryController.FillRecursive(flatObjects);
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string str = "<ol class=\"dd-list\">" + "<li class=\"dd-item\" data-id=\"1\"><div class=\"dd-handle\"><a href=\"/Category/Add/0\">ADD CATEGORY</a></div></li>";
      foreach (TreeNode treeNode in treeNodeList)
      {
        str = str + "<li class=\"dd-item\" data-id=\"1\"><div class=\"dd-handle\">" + treeNode.CategoryName + "</div>";
        foreach (TreeNode child1 in treeNode.Children)
        {
          str = str + "<ol class=\"dd-list\"><li class=\"dd-item\" data-id=\"5\"><div class=\"dd-handle\">" + child1.CategoryName + "</div>";
          foreach (TreeNode child2 in child1.Children)
          {
            str = str + "<ol class=\"dd-list\"><li class=\"dd-item\" data-id=\"6\"><div class=\"dd-handle\">" + child2.CategoryName + "</div>";
            foreach (TreeNode child3 in child2.Children)
              str = str + "<ol class=\"dd-list\"><li class=\"dd-item\" data-id=\"6\"><div class=\"dd-handle\">" + child3.CategoryName + "</div></li></ol>";
            str += "</li></ol>";
          }
          str += "</li></ol>";
        }
        str += "</li>";
      }
      return str + "</ol>";
    }

    private static List<TreeNode> FillRecursive(
      List<Category> flatObjects,
      int? parentId = null)
    {
      return flatObjects.Where<Category>((Func<Category, bool>) (x => x.ParentCategoryId.Equals((object) parentId))).Select<Category, TreeNode>((Func<Category, TreeNode>) (item => new TreeNode()
      {
        CategoryName = item.CategoryName,
        CategoryId = item.CategoryId,
        Children = CategoryController.FillRecursive(flatObjects, new int?(item.CategoryId))
      })).ToList<TreeNode>();
    }
  }
}
