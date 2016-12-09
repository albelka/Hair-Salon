using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HairSalon.Objects
{
  public class Client
  {
    // where TEMPLATE_OBJECTId references a property of the object
    public string Name {get; set;}
    public int StylistId {get; set;}
    public int Id {get; set;}
    // private List<string> TEMPLATE = new List<string> {};

    public Restaurant(string name, int stylistId = 0, int id = 0)
    {
      this.Name = name;
      this.StylistId = stylistId;
      this.Id = id;
    }
  }
}
