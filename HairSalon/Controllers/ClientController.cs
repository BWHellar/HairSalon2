using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }
    // I dont think this is needed.
    [HttpGet("/clients/new")]
    public ActionResult NewClient()
    {
      List<Stylist> listStylist = Stylist.GetAll();
        return View(listStylist);
    }

    [HttpPost("/clients")]
    public ActionResult Create()
    {
      Client client = new Client (Request.Form["newClient"], int.Parse(Request.Form["stylistId"]));
      client.Save();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }

    [HttpGet("/clients/{id}/edit")]
    public ActionResult EditForm(int id)
    {
      Client client = Client.Find(id);
      return View(client);
    }
    [HttpPost("/clients/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Client client = Client.Find(id);
      client.Edit(Request.Form["editClient"]);
      return RedirectToAction("Index");
    }

    [HttpGet("/clients/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Client client = Client.Find(id);
      client.Delete();
      return RedirectToAction("Index");
    }
  }
}
