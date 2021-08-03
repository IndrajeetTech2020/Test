// Decompiled with JetBrains decompiler
// Type: CPJewellery.Models.Item
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace CPJewellery.Models
{
  public class Item
  {
    public int ItemID { get; set; }

    public string ItemName { get; set; }

    public string ItemDescription { get; set; }

    public int Qty { get; set; }

    public string MetalType { get; set; }

    public Decimal Weight { get; set; }

    public Decimal MetalPrice { get; set; }

    public Decimal Price { get; set; }

    public Decimal MakingCharges { get; set; }

    public Decimal MakingChargesAmt { get; set; }

    public Decimal Discount { get; set; }

    public Decimal DiscountAmt { get; set; }

    public Decimal GST { get; set; }

    public Decimal GSTAmt { get; set; }

    public Decimal PriceWithGst { get; set; }

    public string Color { get; set; }

    public string Size { get; set; }

    public string Width { get; set; }

    public string Height { get; set; }

    public string ItemImage { get; set; }

    public int Caret { get; set; }

    public int CategoryID { get; set; }

    public Decimal Subtotal { get; set; }

    public string TransactionID { get; set; }

    public string OrderNo { get; set; }

    public string InvoiceNo { get; set; }

    public string InvoiceDate { get; set; }

    public int InvoiceAmt { get; set; }

    public string ContactNo { get; set; }

    public string Billto { get; set; }

    public string Billaddress { get; set; }

    public List<Item> GetProductsbyCategoryID(int CategoryID)
    {
      MetalRate rates = new MetalRate().GetRates();
      List<Item> objList = new List<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand selectCommand = new SqlCommand("ITEMBYCATEGORYID", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@CATEGORYID", (object) CategoryID);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
        {
          Item obj = new Item();
          obj.ItemID = Convert.ToInt32(row["ITEMID"]);
          obj.ItemName = row["ITEMNAME"].ToString();
          obj.ItemDescription = row["ITEMDESCRIPTION"].ToString();
          obj.Caret = Convert.ToInt32(row["CARET"]);
          obj.MakingCharges = Convert.ToDecimal(row["MAKINGCHARGES"]);
          obj.Weight = Convert.ToDecimal(row["WEIGHT"]);
          obj.ItemImage = row["ITEMIMAGE"].ToString();
          if (dataTable1.Rows[0]["METALTYPE"].ToString() == "GOLD")
          {
            obj.MetalPrice = obj.Caret != 22 ? rates.Gold18Rate : rates.Gold22Rate;
            obj.Discount = rates.GoldMakingChargesDiscount;
            obj.DiscountAmt = obj.MakingCharges * obj.Weight * obj.Discount / 100M;
            obj.MakingChargesAmt = obj.MakingCharges * obj.Weight - obj.DiscountAmt;
            obj.Price = obj.MetalPrice * obj.Weight + obj.MakingChargesAmt;
            obj.GST = rates.GST;
            obj.GSTAmt = obj.Price * obj.GST / 100M;
            obj.PriceWithGst = obj.Price + obj.GSTAmt;
          }
          else
          {
            obj.MetalPrice = rates.SilverRate;
            obj.Discount = rates.SilverMakingChargesDiscount;
            obj.DiscountAmt = obj.MakingCharges * obj.Weight * obj.Discount / 100M;
            obj.MakingChargesAmt = obj.MakingCharges * obj.Weight - obj.DiscountAmt;
            obj.Price = obj.MetalPrice * obj.Weight + obj.MakingChargesAmt;
            obj.GST = rates.GST;
            obj.GSTAmt = obj.Price * obj.GST / 100M;
            obj.PriceWithGst = obj.Price + obj.GSTAmt;
          }
          objList.Add(obj);
        }
      }
      return objList;
    }

    public List<SelectListItem> GetItembyCategoryID(int CategoryID)
    {
      List<SelectListItem> selectListItemList = new List<SelectListItem>();
      using (SqlConnection selectConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        selectConnection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ITEMID,ITEMNAME FROM ITEMS WHERE CATEGORYID=" + (object) CategoryID ?? "", selectConnection);
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

    public List<Item> GetItemImagesbyItemID(int itemID)
    {
      List<Item> objList = new List<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT ITEMIMAGE FROM ITEMIMAGES WHERE ITEMID=" + (object) itemID ?? "", connection));
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
          objList.Add(new Item()
          {
            ItemImage = row["ITEMIMAGE"].ToString()
          });
      }
      return objList;
    }

    public List<Item> GetRelatedItemsbyItemID(int _itemID)
    {
      MetalRate rates = new MetalRate().GetRates();
      List<Item> objList = new List<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand selectCommand = new SqlCommand("RELATEDITEMBYCATEGORYID", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@ITEMID", (object) _itemID);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
        {
          Item obj = new Item();
          obj.ItemID = Convert.ToInt32(row["ITEMID"]);
          obj.ItemName = row["ITEMNAME"].ToString();
          obj.ItemDescription = row["ITEMDESCRIPTION"].ToString();
          obj.Caret = Convert.ToInt32(row["CARET"]);
          obj.MakingCharges = Convert.ToDecimal(row["MAKINGCHARGES"]);
          obj.Weight = Convert.ToDecimal(row["WEIGHT"]);
          obj.ItemImage = row["ITEMIMAGE"].ToString();
          if (dataTable1.Rows[0]["METALTYPE"].ToString() == "GOLD")
          {
            obj.MetalPrice = obj.Caret != 22 ? rates.Gold18Rate : rates.Gold22Rate;
            obj.Discount = rates.GoldMakingChargesDiscount;
            obj.DiscountAmt = obj.MakingCharges * obj.Weight * obj.Discount / 100M;
            obj.MakingChargesAmt = obj.MakingCharges * obj.Weight - obj.DiscountAmt;
            obj.Price = obj.MetalPrice * obj.Weight + obj.MakingChargesAmt;
            obj.GST = rates.GST;
            obj.GSTAmt = obj.Price * obj.GST / 100M;
            obj.PriceWithGst = obj.Price + obj.GSTAmt;
          }
          else
          {
            obj.MetalPrice = rates.SilverRate;
            obj.Discount = rates.SilverMakingChargesDiscount;
            obj.DiscountAmt = obj.MakingCharges * obj.Weight * obj.Discount / 100M;
            obj.MakingChargesAmt = obj.MakingCharges * obj.Weight - obj.DiscountAmt;
            obj.Price = obj.MetalPrice * obj.Weight + obj.MakingChargesAmt;
            obj.GST = rates.GST;
            obj.GSTAmt = obj.Price * obj.GST / 100M;
            obj.PriceWithGst = obj.Price + obj.GSTAmt;
          }
          objList.Add(obj);
        }
      }
      return objList;
    }

    public Item GetItembyItemID(int itemID)
    {
      MetalRate rates = new MetalRate().GetRates();
      Item obj = new Item();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand selectCommand = new SqlCommand("ITEMBYITEMID", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@ITEMID", (object) itemID);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        obj.ItemID = Convert.ToInt32(dataTable1.Rows[0]["ITEMID"]);
        obj.ItemName = dataTable1.Rows[0]["ITEMNAME"].ToString();
        obj.ItemDescription = dataTable1.Rows[0]["ITEMDESCRIPTION"].ToString();
        obj.Caret = Convert.ToInt32(dataTable1.Rows[0]["CARET"]);
        obj.MakingCharges = Convert.ToDecimal(dataTable1.Rows[0]["MAKINGCHARGES"]);
        obj.Weight = Convert.ToDecimal(dataTable1.Rows[0]["WEIGHT"]);
        obj.Color = dataTable1.Rows[0]["COLOR"].ToString();
        obj.Size = dataTable1.Rows[0]["SIZE"].ToString();
        obj.Width = dataTable1.Rows[0]["WIDTH"].ToString();
        obj.Height = dataTable1.Rows[0]["HEIGHT"].ToString();
        obj.Caret = Convert.ToInt32(dataTable1.Rows[0]["CARET"]);
        obj.Qty = Convert.ToInt32(dataTable1.Rows[0]["OPENINGQTY"]);
        obj.ItemImage = dataTable1.Rows[0]["OPENINGQTY"].ToString();
        if (dataTable1.Rows[0]["METALTYPE"].ToString() == "GOLD")
        {
          obj.MetalPrice = obj.Caret != 22 ? rates.Gold18Rate : rates.Gold22Rate;
          obj.Discount = rates.GoldMakingChargesDiscount;
          obj.DiscountAmt = obj.MakingCharges * obj.Weight * obj.Discount / 100M;
          obj.MakingChargesAmt = obj.MakingCharges * obj.Weight - obj.DiscountAmt;
          obj.Price = obj.MetalPrice * obj.Weight + obj.MakingChargesAmt;
          obj.GST = rates.GST;
          obj.GSTAmt = obj.Price * obj.GST / 100M;
          obj.PriceWithGst = obj.Price + obj.GSTAmt;
        }
        else
        {
          obj.MetalPrice = rates.SilverRate;
          obj.Discount = rates.SilverMakingChargesDiscount;
          obj.DiscountAmt = obj.MakingCharges * obj.Weight * obj.Discount / 100M;
          obj.MakingChargesAmt = obj.MakingCharges * obj.Weight - obj.DiscountAmt;
          obj.Price = obj.MetalPrice * obj.Weight + obj.MakingChargesAmt;
          obj.GST = rates.GST;
          obj.GSTAmt = obj.Price * obj.GST / 100M;
          obj.PriceWithGst = obj.Price + obj.GSTAmt;
        }
      }
      return obj;
    }

    public bool Save(Item item, List<string> itemimages)
    {
      bool flag = false;
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
          SqlCommand selectCommand = new SqlCommand("ITEMSAVE", connection, transaction);
          selectCommand.CommandType = CommandType.StoredProcedure;
          selectCommand.Parameters.AddWithValue("@ITEMNAME", (object) item.ItemName);
          selectCommand.Parameters.AddWithValue("@ITEMDESCRIPTION", (object) item.ItemDescription);
          selectCommand.Parameters.AddWithValue("@QTY", (object) item.Qty);
          selectCommand.Parameters.AddWithValue("@METALTYPE", (object) item.MetalType);
          selectCommand.Parameters.AddWithValue("@CARET", (object) item.Caret);
          selectCommand.Parameters.AddWithValue("@WEIGHT", (object) item.Weight);
          selectCommand.Parameters.AddWithValue("@COLOR", (object) item.Color);
          selectCommand.Parameters.AddWithValue("@SIZE", (object) item.Size);
          selectCommand.Parameters.AddWithValue("@WIDTH", (object) item.Width);
          selectCommand.Parameters.AddWithValue("@HEIGHT", (object) item.Height);
          selectCommand.Parameters.AddWithValue("@MAKINGCHARGES", (object) item.MakingCharges);
          selectCommand.Parameters.AddWithValue("@CATEGORYID", (object) item.CategoryID);
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = dataTable1;
          sqlDataAdapter.Fill(dataTable2);
          foreach (string itemimage in itemimages)
            new SqlCommand("INSERT INTO ITEMIMAGES(ITEMID,ITEMIMAGE) VALUES('" + dataTable1.Rows[0][0].ToString() + "','" + itemimage + "')", connection, transaction).ExecuteNonQuery();
          transaction.Commit();
          flag = true;
        }
        catch
        {
          transaction.Rollback();
        }
      }
      return flag;
    }

    public string SaveInvoice(List<Item> itemlist, int createdby)
    {
      DataTable dataTable = new DataTable();
      Item obj1 = itemlist.FirstOrDefault<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
          if (obj1.GST != 0M)
          {
            SqlCommand selectCommand = new SqlCommand("INVOICEMASTERSAVE", connection, transaction);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@INVOICEDATE", (object) DateTime.Now.AddHours(4.0));
            selectCommand.Parameters.AddWithValue("@SUBTOTAL", (object) obj1.Subtotal);
            selectCommand.Parameters.AddWithValue("@GST", (object) obj1.GST);
            selectCommand.Parameters.AddWithValue("@GSTAMOUNT", (object) obj1.GSTAmt);
            selectCommand.Parameters.AddWithValue("@INVOICEAMT", (object) obj1.PriceWithGst);
            selectCommand.Parameters.AddWithValue("@INVOICETYPE", (object) "OFFLINE");
            selectCommand.Parameters.AddWithValue("@BILLTO", (object) obj1.Billto);
            selectCommand.Parameters.AddWithValue("@BILLADDRESS", (object) obj1.Billaddress);
            selectCommand.Parameters.AddWithValue("@CREATEDBY", (object) createdby);
            new SqlDataAdapter(selectCommand).Fill(dataTable);
            foreach (Item obj2 in itemlist)
            {
              SqlCommand sqlCommand = new SqlCommand("INVOICEDETAILSAVE", connection, transaction);
              sqlCommand.CommandType = CommandType.StoredProcedure;
              sqlCommand.Parameters.AddWithValue("@INVOICENO", (object) dataTable.Rows[0][0].ToString());
              sqlCommand.Parameters.AddWithValue("@ITEMID", (object) obj2.ItemID);
              sqlCommand.Parameters.AddWithValue("@ITEMNAME", (object) obj2.ItemName);
              sqlCommand.Parameters.AddWithValue("@ITEMDESCRIPTION", (object) obj2.ItemDescription);
              sqlCommand.Parameters.AddWithValue("@WEIGHT", (object) obj2.Weight);
              sqlCommand.Parameters.AddWithValue("@CARET", (object) obj2.Caret);
              sqlCommand.Parameters.AddWithValue("@METALPRICE", (object) obj2.MetalPrice);
              sqlCommand.Parameters.AddWithValue("@MAKINGCHARGES", (object) obj2.MakingCharges);
              sqlCommand.Parameters.AddWithValue("@MAKINGCHARGESAMT", (object) obj2.MakingChargesAmt);
              sqlCommand.Parameters.AddWithValue("@DISCOUNT", (object) obj2.Discount);
              sqlCommand.Parameters.AddWithValue("@DISCOUNTAMT", (object) obj2.DiscountAmt);
              sqlCommand.Parameters.AddWithValue("@PRICE", (object) obj2.Price);
              sqlCommand.ExecuteNonQuery();
            }
          }
          else
          {
            SqlCommand selectCommand = new SqlCommand("NONINVOICEMASTERSAVE", connection, transaction);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@INVOICEDATE", (object) DateTime.Now.AddHours(4.0));
            selectCommand.Parameters.AddWithValue("@SUBTOTAL", (object) obj1.Subtotal);
            selectCommand.Parameters.AddWithValue("@GST", (object) obj1.GST);
            selectCommand.Parameters.AddWithValue("@GSTAMOUNT", (object) obj1.GSTAmt);
            selectCommand.Parameters.AddWithValue("@INVOICEAMT", (object) obj1.PriceWithGst);
            selectCommand.Parameters.AddWithValue("@INVOICETYPE", (object) "OFFLINE");
            selectCommand.Parameters.AddWithValue("@BILLTO", (object) obj1.Billto);
            selectCommand.Parameters.AddWithValue("@BILLADDRESS", (object) obj1.Billaddress);
            selectCommand.Parameters.AddWithValue("@CREATEDBY", (object) createdby);
            new SqlDataAdapter(selectCommand).Fill(dataTable);
            foreach (Item obj2 in itemlist)
            {
              SqlCommand sqlCommand = new SqlCommand("NONINVOICEDETAILSAVE", connection, transaction);
              sqlCommand.CommandType = CommandType.StoredProcedure;
              sqlCommand.Parameters.AddWithValue("@INVOICENO", (object) dataTable.Rows[0][0].ToString());
              sqlCommand.Parameters.AddWithValue("@ITEMID", (object) obj2.ItemID);
              sqlCommand.Parameters.AddWithValue("@ITEMNAME", (object) obj2.ItemName);
              sqlCommand.Parameters.AddWithValue("@ITEMDESCRIPTION", (object) obj2.ItemDescription);
              sqlCommand.Parameters.AddWithValue("@WEIGHT", (object) obj2.Weight);
              sqlCommand.Parameters.AddWithValue("@CARET", (object) obj2.Caret);
              sqlCommand.Parameters.AddWithValue("@METALPRICE", (object) obj2.MetalPrice);
              sqlCommand.Parameters.AddWithValue("@MAKINGCHARGES", (object) obj2.MakingCharges);
              sqlCommand.Parameters.AddWithValue("@MAKINGCHARGESAMT", (object) obj2.MakingChargesAmt);
              sqlCommand.Parameters.AddWithValue("@DISCOUNT", (object) obj2.Discount);
              sqlCommand.Parameters.AddWithValue("@DISCOUNTAMT", (object) obj2.DiscountAmt);
              sqlCommand.Parameters.AddWithValue("@PRICE", (object) obj2.Price);
              sqlCommand.ExecuteNonQuery();
            }
          }
          transaction.Commit();
          return dataTable.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
          transaction.Rollback();
          return ex.Message;
        }
        finally
        {
          transaction.Dispose();
        }
      }
    }

    public List<Item> InvoicebyID(int _invoiceno)
    {
      List<Item> objList = new List<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand selectCommand = new SqlCommand("INVOICEDETAILSBYNO", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@INVOICENO", (object) _invoiceno);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
          objList.Add(new Item()
          {
            ItemName = row["ITEMNAME"].ToString(),
            ItemDescription = row["ITEMDESCRIPTION"].ToString(),
            Weight = Convert.ToDecimal(row["WEIGHT"]),
            Caret = Convert.ToInt32(row["CARET"]),
            MetalPrice = Convert.ToDecimal(row["METALPRICE"]),
            MakingChargesAmt = Convert.ToDecimal(row["MAKINGCHARGESAMT"]),
            Discount = Convert.ToDecimal(row["DISCOUNT"]),
            DiscountAmt = Convert.ToDecimal(row["DISCOUNTAMT"]),
            Price = Convert.ToDecimal(row["PRICE"]),
            InvoiceNo = row["INVOICENO"].ToString(),
            InvoiceDate = row["INVOICEDATE"].ToString(),
            Billto = row["BILLTO"].ToString(),
            Billaddress = row["BILLADDRESS"].ToString(),
            Subtotal = Convert.ToDecimal(row["SUBTOTAL"]),
            GST = Convert.ToDecimal(row["GST"]),
            GSTAmt = Convert.ToDecimal(row["GSTAMOUNT"]),
            PriceWithGst = Convert.ToDecimal(row["INVOICEAMT"])
          });
      }
      return objList;
    }

    public List<Item> NonInvoicebyID(int _invoiceno)
    {
      List<Item> objList = new List<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand selectCommand = new SqlCommand("NONINVOICEDETAILSBYNO", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@INVOICENO", (object) _invoiceno);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        foreach (DataRow row in (InternalDataCollectionBase) dataTable1.Rows)
          objList.Add(new Item()
          {
            ItemName = row["ITEMNAME"].ToString(),
            ItemDescription = row["ITEMDESCRIPTION"].ToString(),
            Weight = Convert.ToDecimal(row["WEIGHT"]),
            Caret = Convert.ToInt32(row["CARET"]),
            MetalPrice = Convert.ToDecimal(row["METALPRICE"]),
            MakingChargesAmt = Convert.ToDecimal(row["MAKINGCHARGESAMT"]),
            Discount = Convert.ToDecimal(row["DISCOUNT"]),
            DiscountAmt = Convert.ToDecimal(row["DISCOUNTAMT"]),
            Price = Convert.ToDecimal(row["PRICE"]),
            InvoiceNo = row["INVOICENO"].ToString(),
            InvoiceDate = row["INVOICEDATE"].ToString(),
            Billto = row["BILLTO"].ToString(),
            Billaddress = row["BILLADDRESS"].ToString(),
            Subtotal = Convert.ToDecimal(row["SUBTOTAL"]),
            GST = Convert.ToDecimal(row["GST"]),
            GSTAmt = Convert.ToDecimal(row["GSTAMOUNT"]),
            PriceWithGst = Convert.ToDecimal(row["INVOICEAMT"])
          });
      }
      return objList;
    }

    public Item SaveTransaction(List<Item> itemlist)
    {
      Decimal num1 = 0M;
      Decimal num2 = 0M;
      Decimal num3 = 0M;
      string str = Guid.NewGuid().ToString();
      Item obj1 = itemlist.FirstOrDefault<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
          foreach (Item obj2 in itemlist)
          {
            SqlCommand sqlCommand = new SqlCommand("TRANSACTIONDETAILSAVE", connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@TRANSACTIONID", (object) str);
            sqlCommand.Parameters.AddWithValue("@ITEMID", (object) obj2.ItemID);
            sqlCommand.Parameters.AddWithValue("@ITEMNAME", (object) obj2.ItemName);
            sqlCommand.Parameters.AddWithValue("@ITEMDESCRIPTION", (object) obj2.ItemDescription);
            sqlCommand.Parameters.AddWithValue("@CARET", (object) obj2.Caret);
            sqlCommand.Parameters.AddWithValue("@METALPRICE", (object) obj2.MetalPrice);
            sqlCommand.Parameters.AddWithValue("@MAKINGCHARGES", (object) obj2.MakingCharges);
            sqlCommand.Parameters.AddWithValue("@MAKINGCHARGESAMT", (object) obj2.MakingChargesAmt);
            sqlCommand.Parameters.AddWithValue("@DISCOUNT", (object) obj2.Discount);
            sqlCommand.Parameters.AddWithValue("@DISCOUNTAMT", (object) obj2.DiscountAmt);
            sqlCommand.Parameters.AddWithValue("@PRICE", (object) obj2.Price);
            sqlCommand.ExecuteNonQuery();
            num1 += obj2.Price;
            num2 += obj2.GSTAmt;
            num3 += obj2.PriceWithGst;
          }
          SqlCommand selectCommand = new SqlCommand("TRANSACTIONMASTERSAVE", connection, transaction);
          selectCommand.CommandType = CommandType.StoredProcedure;
          selectCommand.Parameters.AddWithValue("@TRANSACTIONID", (object) str);
          selectCommand.Parameters.AddWithValue("@INVOICEDATE", (object) DateTime.Now);
          selectCommand.Parameters.AddWithValue("@SUBTOTAL", (object) num1);
          selectCommand.Parameters.AddWithValue("@GST", (object) obj1.GST);
          selectCommand.Parameters.AddWithValue("@GSTAMOUNT", (object) num2);
          selectCommand.Parameters.AddWithValue("@INVOICEAMT", (object) num3);
          new SqlDataAdapter(selectCommand).Fill(new DataTable());
          transaction.Commit();
        }
        catch (Exception ex)
        {
          transaction.Rollback();
        }
        finally
        {
          transaction.Dispose();
        }
      }
      return new Item()
      {
        InvoiceAmt = Convert.ToInt32(num3),
        TransactionID = str
      };
    }

    public void updatetransaction(
      PaymentInitiateModel paymentdetails,
      string orderno,
      string transactionid)
    {
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand sqlCommand = new SqlCommand("TRANSACTIONMASTERUPDATE", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@TRANSACTIONID", (object) transactionid);
        sqlCommand.Parameters.AddWithValue("@ORDERNO", (object) orderno);
        sqlCommand.Parameters.AddWithValue("@CONTACTNO", (object) paymentdetails.contactNumber);
        sqlCommand.Parameters.AddWithValue("@BILLTO", (object) paymentdetails.name);
        sqlCommand.Parameters.AddWithValue("@BILLADDRESS", (object) paymentdetails.address);
        sqlCommand.ExecuteNonQuery();
      }
    }

    public void updatetransactionstatus(string orderno, string paymentgatewayid)
    {
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand sqlCommand = new SqlCommand("TRANSACTIONSTATUSUPDATE", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@ORDERNO", (object) orderno);
        sqlCommand.Parameters.AddWithValue("@PAYMENTGATEWAYID", (object) paymentgatewayid);
        sqlCommand.Parameters.AddWithValue("@DATE", (object) DateTime.Now.AddHours(4.0));
        sqlCommand.ExecuteNonQuery();
      }
    }

    public string SavePurchase(List<Item> itemlist, int createdby)
    {
      Item obj1 = itemlist.FirstOrDefault<Item>();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
          SqlCommand selectCommand = new SqlCommand("PURCHASEMASTERSAVE", connection, transaction);
          selectCommand.CommandType = CommandType.StoredProcedure;
          selectCommand.Parameters.AddWithValue("@INVOICEDATE", (object) obj1.InvoiceDate);
          selectCommand.Parameters.AddWithValue("@SUBTOTAL", (object) obj1.Subtotal);
          selectCommand.Parameters.AddWithValue("@CREATEDBY", (object) createdby);
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
          DataTable dataTable1 = new DataTable();
          DataTable dataTable2 = dataTable1;
          sqlDataAdapter.Fill(dataTable2);
          foreach (Item obj2 in itemlist)
          {
            SqlCommand sqlCommand = new SqlCommand("PURCHASEDETAILSAVE", connection, transaction);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@PURCHASEID", (object) dataTable1.Rows[0][0].ToString());
            sqlCommand.Parameters.AddWithValue("@ITEMID", (object) obj2.ItemID);
            sqlCommand.Parameters.AddWithValue("@ITEMNAME", (object) obj2.ItemName);
            sqlCommand.Parameters.AddWithValue("@ITEMDESCRIPTION", (object) obj2.ItemDescription);
            sqlCommand.Parameters.AddWithValue("@ITEMDESCRIPTION", (object) obj2.Qty);
            sqlCommand.Parameters.AddWithValue("@PRICE", (object) obj2.Price);
            sqlCommand.ExecuteNonQuery();
          }
          transaction.Commit();
          return dataTable1.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
          transaction.Rollback();
          return ex.Message;
        }
        finally
        {
          transaction.Dispose();
        }
      }
    }
  }
}
