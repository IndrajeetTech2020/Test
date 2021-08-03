// Decompiled with JetBrains decompiler
// Type: CPJewellery.Models.TreeNode
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System.Collections.Generic;

namespace CPJewellery.Models
{
  public class TreeNode
  {
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public TreeNode ParentCategory { get; set; }

    public List<TreeNode> Children { get; set; }
  }
}
