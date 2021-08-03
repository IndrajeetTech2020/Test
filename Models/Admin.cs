// Decompiled with JetBrains decompiler
// Type: CPJewellery.Models.Admin
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CPJewellery.Models
{
  public class Admin
  {
    public int ID { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public bool Isadmin { get; set; }

    public string AdminType { get; set; }

    public Admin CheckAdmin(Admin _admin)
    {
      Admin admin = new Admin();
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        connection.Open();
        SqlCommand selectCommand = new SqlCommand("ADMINLOGIN", connection);
        selectCommand.CommandType = CommandType.StoredProcedure;
        selectCommand.Parameters.AddWithValue("@USERNAME", (object) _admin.Username);
        selectCommand.Parameters.AddWithValue("@PASSWORD", (object) _admin.Password);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = dataTable1;
        sqlDataAdapter.Fill(dataTable2);
        if (dataTable1.Rows.Count > 0)
        {
          admin.Isadmin = true;
          admin.AdminType = dataTable1.Rows[0]["ADMINTYPE"].ToString();
        }
        else
          admin.Isadmin = false;
      }
      return admin;
    }
  }
}
