using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyControllerTest
  {
    [TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      SpecialtyController controller = new SpecialtyController();
      ActionResult view = controller.Index();
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModel_SpecialtyList()
    {
      SpecialtyController controller = new SpecialtyController();
      IActionResult actionResult = controller.Index();
      ViewResult view = controller.Index() as ViewResult;
      var result = view.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Specialty>));
    }
    
    [TestMethod]
    public void ShowSpecial_ReturnsCorrectView_True()
    {
      SpecialtyController controller = new SpecialtyController();
      ActionResult view = controller.ShowSpecial(0);
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }
  }
}
