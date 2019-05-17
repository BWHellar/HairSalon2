using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using MySql.Data.MySqlClient;

namespace HairSalon.Test
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=brendan_hellar_test;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }

    [TestMethod]
    public void Save_Test()
    {
      Stylist stylist = new Stylist("Test");
      stylist.Save();
      List<Stylist> list = new List<Stylist>{stylist};
      List<Stylist> result = Stylist.GetAll();

      CollectionAssert.AreEqual(list, result);
    }
  }
}
