// Decompiled with JetBrains decompiler
// Type: CPJewellery.Models.Category
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace CPJewellery.Models
{
  public class Category
  {
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public int? ParentCategoryId { get; set; }

    public DataTable getcategories()
    {
      DataTable dataTable = new DataTable();
      using (SqlConnection selectConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        selectConnection.Open();
        new SqlDataAdapter("CATEGORYLIST", selectConnection).Fill(dataTable);
      }
      return dataTable;
    }

    public string Save(Category category)
    {
      string str = "";
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        try
        {
          connection.Open();
          SqlCommand sqlCommand = new SqlCommand("CATEGORYSAVE", connection);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@PARENTID", (object) category.ParentCategoryId);
          sqlCommand.Parameters.AddWithValue("@CATEGORYNAME", (object) category.CategoryName);
          str = sqlCommand.ExecuteNonQuery() != 0 ? "saved" : "unsaved";
        }
        catch (Exception ex)
        {
          str = ex.Message;
        }
      }
      return str;
    }

    public List<SelectListItem> L1list()
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>();
      using (SqlConnection selectConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        selectConnection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select CATEGORYID,CATEGORYNAME from CATEGORY WHERE PARENTCATEGORYID=0", selectConnection);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
          selectListItemList.Add(new SelectListItem()
          {
            Text = row[1].ToString(),
            Value = row[0].ToString()
          });
        return selectListItemList;
      }
    }

    public List<SelectListItem> L2list()
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>();
      using (SqlConnection selectConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        selectConnection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select CATEGORYID,CATEGORYNAME from CATEGORY WHERE PARENTCATEGORYID=0", selectConnection);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
          selectListItemList.Add(new SelectListItem()
          {
            Text = row[1].ToString(),
            Value = row[0].ToString()
          });
        return selectListItemList;
      }
    }

    public List<SelectListItem> GetCategorybyParent(int _ParentCategoryID)
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>();
      using (SqlConnection selectConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        selectConnection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select CATEGORYID,CATEGORYNAME from CATEGORY WHERE PARENTCATEGORYID=" + (object) _ParentCategoryID ?? "", selectConnection);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
          selectListItemList.Add(new SelectListItem()
          {
            Text = row["CATEGORYNAME"].ToString(),
            Value = row["CATEGORYID"].ToString()
          });
        return selectListItemList;
      }
    }
  }
}
