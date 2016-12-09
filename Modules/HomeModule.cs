using Nancy;
using System.Collections.Generic;
using Nancy.ViewEngines.Razor;


namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
      {
        Get["/"] = _ => {
          return View["index.cshtml"];
        };
        Get["stylists/new"] = _ => {
          return View["stylists-new.cshtml"];
        };
        Post["stylist/new"] = _ => {
          Stylist newStylist = new Stylist(Request.Form("name"), Request.Form("availability"));
          newStylist.Save();
          List<Stylist> allStylists = Stylist.GetAll();

          return View["stylists.cshtml", allStylists];
        };
        // Get["/stylists/{id}"] = parameters => {
        //   var selectedStylist = Stylist.Find(parameters.id);
        //
        // }


      }
  }
}
