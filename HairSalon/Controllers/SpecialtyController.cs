using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult NewSpecial()
    {
      return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create()
    {
      Specialty specialty = new Specialty (Request.Form["newSpecialty"]);
      specialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpGet("/specialties/{id}/edit")]
    public ActionResult EditForm(int id)
    {
      Specialty specialty = Specialty.Find(id);
      return View(specialty);
    }

    [HttpPost("/specialties/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Specialty specialty = Specialty.Find(id);
      specialty.Edit(Request.Form["editSpecialty"]);
      return RedirectToAction("Index");
    }

    [HttpGet("/specialties/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Specialty specialty = Specialty.Find(id);
      specialty.Delete();
      return RedirectToAction("Index");
    }

    [HttpPost("/specialties/{specialtyId}/stylists/new")]
    public ActionResult AddSpecialty(int specialtyId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      Stylist stylist = Stylist.Find(int.Parse(Request.Form["stylistid"]));
      specialty.AddStylist(stylist);
      return RedirectToAction("Index",  new { id = specialtyId });
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult ShowSpecial(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> selectedStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("allStylists", allStylists);
      model.Add("selectedSpecialty", selectedSpecialty);
      model.Add("selectedStylists", selectedStylists);
      return View(model);
    }
  }
}
