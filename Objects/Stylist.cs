using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon
{
  public class Stylist
  {
    // where TEMPLATE_OBJECTId references a property of the object
    public string Name {get; set;}
    public string Availability {get; set;}
    public int Id {get; set;}

    public Stylist(string name, string availability, int id = 0)
    {
      this.Name = name;
      this.Availability = availability;
      this.Id = id;
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        string stylistAvailability = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistAvailability, stylistId);
        allStylists.Add(newStylist);
      }
      if(rdr!=null)
      {
        rdr.Close();
      }
      if(conn!=null)
      {
        conn.Close();
      }
      return allStylists;
    }
  }
}
