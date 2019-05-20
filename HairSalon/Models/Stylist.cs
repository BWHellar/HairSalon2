using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    public string Name { get { return _name;} }

    private int _id;
    public int Id { get { return _id;} }

    public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public override int GetHashCode()
    {return this.Id.GetHashCode();}

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
          return false;
      }
      else
      {
          Stylist newStylist = (Stylist)otherStylist;
          bool idEquality = this.Id == newStylist.Id;
          bool nameEquality = this.Name == newStylist.Name;
          return (idEquality && nameEquality);
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylist; DELETE FROM specialties; DELETE FROM stylistSpecialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist (Name) VALUES (@name);";
      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylist;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistName = rdr.GetString(1);
        Stylist stylist = new Stylist(StylistName, StylistId);
        allStylists.Add(stylist);
      }
      conn.Close();
      if (conn != null){conn.Dispose();}
      return allStylists;
    }

   public static Stylist Find(int id)
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM stylist WHERE id = (@searchId);";
     MySqlParameter searchId = new MySqlParameter();
     searchId.ParameterName = "@searchId";
     searchId.Value = id;
     cmd.Parameters.Add(searchId);
     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     int StylistId = 0;
     string StylistName = "";
     while(rdr.Read())
     {
       StylistId = rdr.GetInt32(0);
       StylistName = rdr.GetString(1);
     }
     Stylist stylist = new Stylist(StylistName, StylistId);
     conn.Close();
     if (conn != null){conn.Dispose();}
     return stylist;
    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylist SET Name = @newName WHERE id = @searchId;";
      cmd.Parameters.Add(new MySqlParameter("@searchId", _id));
      cmd.Parameters.Add(new MySqlParameter("@newName", newName));
      cmd.ExecuteNonQuery();
      _name = newName;
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylist WHERE id = @thisId;";
      cmd.Parameters.Add(new MySqlParameter("@searchId", _id));
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null){conn.Dispose();}
    }
  }
}
