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

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.Id == newStylist.Id;
        bool nameEquality = this.Id == newStylist.Id;
        bool availabilityEquality = this.Availability ==newStylist.Availability;

        return(nameEquality && availabilityEquality && idEquality);
      }
    }
    public override int GetHashCode()
    {
         return this.Name.GetHashCode();
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
        string stylistAvailability = rdr.GetString(2);
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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, availability) OUTPUT INSERTED.id VALUES (@StylistName, @StylistAvailability);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StylistName";
      nameParameter.Value = this.Name;

      SqlParameter availabilityParameter = new SqlParameter();
      availabilityParameter.ParameterName = "@StylistAvailability";
      availabilityParameter.Value = this.Availability;
      
      cmd.Parameters.Add(availabilityParameter);
      cmd.Parameters.Add(nameParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteReader();
      conn.Close();
    }
  }
}
