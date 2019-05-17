using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientControllerTest
  {
    TestMethod]
    public void Index_ReturnsCorrectView_True()
    {
      ClientController controller = new ClientController();
      ActionResult view = controller.Index();
      Assert.IsInstanceOfType(view, typeof(ViewResult));
    }

    [TestMethod]
    public void Index_HasCorrectModel_ClientList()
    {
      ClientController controller = new ClientController();
      IActionResult actionResult = controller.Index();
      ViewResult indexView = controller.Index() as ViewResult;
      var result = indexView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Client>));
    }
  }
}
