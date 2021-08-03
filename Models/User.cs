// Decompiled with JetBrains decompiler
// Type: CPJewellery.Models.User
// Assembly: CPJewellery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08B1BF70-75EA-4ED8-BE49-5527D3C62745
// Assembly location: D:\Indrajeet\CPJewelleryProj\CPJewelleryProj\bin\CPJewellery.dll

using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CPJewellery.Models
{
  public class User
  {
    public string Username { get; set; }

    public string Password { get; set; }

    public bool IsUser { get; set; }

    public string UserType { get; set; }

    public string saveuser(User _user)
    {
      string str = "";
      using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CP"].ConnectionString))
      {
        try
        {
          connection.Open();
          str = new SqlCommand("INSERT INTO ADMINUSERS(USERNAME,PASSWORD,ADMINTYPE) VALUES('" + _user.Username + "','" + _user.Password + "','" + _user.UserType + "')", connection).ExecuteNonQuery() != 0 ? "saved" : "unsaved";
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
