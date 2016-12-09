using Nancy;
using System;
using System.Collections.Generic;
using Nancy.ViewEngines.Razor;


namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
      {
        Get["/"] = _ => {
          List<Stylist> AllLists = Stylist.GetAll();
          return View["index.cshtml"];
        };
        Get["/stylists"] = _ => {
          var AllStylists = Stylist.GetAll();
          return View["stylists.cshtml", AllStylists];
        };
        Get["/clients"] = _ => {
          var AllClients = Client.GetAll();
          return View ["clients.cshtml", AllClients];
        };
        Get["/stylists/new"] = _ => {
          return View["stylists_form.cshtml"];
        };
        Post["/stylists/new"] = _ => {
          Stylist newStylist = new Stylist(Request.Form["name"], Request.Form["availability"]);
          newStylist.Save();
          List<Stylist> allStylists = Stylist.GetAll();
          return View["success.cshtml"];
        };
        Get["/client/new"] = _ => {
          List<Stylist> AllStylists = Stylist.GetAll();
          return View["clients_form.cshtml", AllStylists];
        };

        Post["/clients/new"] = _ => {
          Client newClient = new Client(Request.Form["client-name"],Request.Form["stylist"]);
          newClient.Save();
          return View["success.cshtml"];
        };
        Post["/clients/delete"] = _ => {
          Client.DeleteAll();
          return View["cleared.cshtml"];
        };
        Get["/stylists/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string,object>();
          var selectedStylist = Stylist.Find(parameters.id);
          var stylistClientsList = selectedStylist.GetClients();
          model.Add("stylist", selectedStylist);
          model.Add("clients", stylistClientsList);
          return View["stylist.cshtml", model];
        };


      }
  }
}
