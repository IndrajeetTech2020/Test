// Decompiled with JetBrains decompiler
// Type: CPJewellery.Models.MetalRate
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPJewellery.Models
{
  public class MetalRate
  {
    public Decimal Gold22Rate { get; set; }

    public Decimal Gold18Rate { get; set; }

    public Decimal SilverRate { get; set; }

    public Decimal GoldMakingChargesDiscount { get; set; }

    public Decimal SilverMakingChargesDiscount { get; set; }

    public Decimal GST { get; set; }

    public MetalRate GetRates()
    {
      MetalRate metalRate = new MetalRate();
      using (SqlConnection selectConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        selectConnection.Open();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT GOLD22RATE,GOLD18RATE,SILVERRATE,GOLDMAKINGCHARGESDISCOUNT,SILVERMAKINGCHARGESDISCOUNT,GST FROM RATES", selectConnection);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        metalRate.Gold22Rate = Convert.ToDecimal(dataTable1.Rows[0]["GOLD22RATE"]);
        metalRate.Gold18Rate = Convert.ToDecimal(dataTable1.Rows[0]["GOLD18RATE"]);
        metalRate.SilverRate = Convert.ToDecimal(dataTable1.Rows[0]["SILVERRATE"]);
        metalRate.GoldMakingChargesDiscount = Convert.ToDecimal(dataTable1.Rows[0]["GOLDMAKINGCHARGESDISCOUNT"]);
        metalRate.SilverMakingChargesDiscount = Convert.ToDecimal(dataTable1.Rows[0]["SILVERMAKINGCHARGESDISCOUNT"]);
        metalRate.GST = Convert.ToDecimal(dataTable1.Rows[0]["GST"]);
      }
      return metalRate;
    }

    public string UpdateRates(MetalRate _metalrate)
    {
      string str = "";
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        try
        {
          connection.Open();
          str = new SqlCommand("UPDATE RATES SET GOLD22RATE='" + (object) _metalrate.Gold22Rate + "',GOLD18RATE='" + (object) _metalrate.Gold18Rate + "',SILVERRATE='" + (object) _metalrate.SilverRate + "',GOLDMAKINGCHARGESDISCOUNT='" + (object) _metalrate.GoldMakingChargesDiscount + "',SILVERMAKINGCHARGESDISCOUNT='" + (object) _metalrate.SilverMakingChargesDiscount + "',GST='" + (object) _metalrate.GST + "'", connection).ExecuteNonQuery() != 0 ? "saved" : "unsaved";
        }
        catch (Exception ex)
        {
          str = ex.Message;
        }
      }
      return str;
    }
  }
}
