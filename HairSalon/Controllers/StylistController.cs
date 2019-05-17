using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult NewStylist()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create()
    {
      Stylist stylist = new Stylist (Request.Form["newStylist"]);
      stylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

    [HttpGet("/stylists/{id}/edit")]
    public ActionResult EditForm(int id)
    {
      Stylist stylist = Stylist.Find(id);
      return View(stylist);
    }

    [HttpPost("/stylists/{id}")]
    public ActionResult Edit(int id)
    {
      Stylist stylist = Stylist.Find(id);
      stylist.Edit(Request.Form["editStylist"]);
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Stylist stylist = Stylist.Find(id);
      stylist.Delete();
      return RedirectToAction("Index");
    }
  }
}
