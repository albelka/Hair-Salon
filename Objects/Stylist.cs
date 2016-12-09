using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class Stylist
  {
    // where TEMPLATE_OBJECTId references a property of the object
    public string Name {get; set;}
    public string Availability {get; set;}
    public int Id {get; set;}

    public Cuisine(string name, string availability, int id = 0)
    {
      this.Name = name;
      this.Availability = availability;
      this.Id = id;
    }
  }
}
