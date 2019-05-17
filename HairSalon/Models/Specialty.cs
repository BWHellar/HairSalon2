using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private int _specialtyId;
    public int specialtyId { get { return _specialtyId;} }

    private string _specialtyName;
    public string specialtyName { get { return _specialtyName;} }

    public Specialty(string SpecialtyName, int SpecialtyId = 0)
    {
      _specialtyId = SpecialtyId;
      _specialtyName = SpecialtyName;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if(!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty specialty = (Specialty) otherSpecialty;
        bool idEquality = (this.specialtyId == specialty.specialtyId);
        bool nameEquality = (this.specialtyName == specialty.specialtyName);
        return(idEquality && nameEquality);
      }
    }

    public override int GetHashCode()
    {return this.specialtyId.GetHashCode();}

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties; DELETE FROM stylist; DELETE FROM stylistSpecialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (Name) VALUES (@name);";
      cmd.Parameters.Add(new MySqlParameter("@name", _specialtyName));
      cmd.ExecuteNonQuery();
      _specialtyId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialty = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int SpecialtyId = rdr.GetInt32(0);
        string SpecialtyName = rdr.GetString(1);
        Specialty specialty = new Specialty(SpecialtyName, SpecialtyId);
        allSpecialty.Add(specialty);
      }
      conn.Close();
      if (conn != null){conn.Dispose();}
      return allSpecialty;
    }

    public static Specialty Find(int id)
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";
     MySqlParameter searchId = new MySqlParameter();
     searchId.ParameterName = "@searchId";
     searchId.Value = id;
     cmd.Parameters.Add(searchId);
     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     int SpecialtyId = 0;
     string SpecialtyName = "";
     while(rdr.Read())
     {
       SpecialtyId = rdr.GetInt32(0);
       SpecialtyName = rdr.GetString(1);
     }
     Specialty specialty = new Specialty(SpecialtyName, SpecialtyId);
     conn.Close();
     if (conn != null){conn.Dispose();}
     return specialty;
    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE specialties SET Name = @newName WHERE id = @searchId;";
      cmd.Parameters.Add(new MySqlParameter("@searchId", _specialtyId));
      cmd.Parameters.Add(new MySqlParameter("@newName", newName));
      cmd.ExecuteNonQuery();
      _specialtyName = newName;
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties WHERE id = @thisId; DELETE FROM stylistSpecialties WHERE specialtyId = @thisId";
      cmd.Parameters.Add(new MySqlParameter("@thisId", _specialtyId));
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null){conn.Dispose();}
    }

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylistSpecialties (stylistId, specialtyId) VALUES (@StylistId, @SpecialtyId);";
      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", _specialtyId));
      cmd.Parameters.Add(new MySqlParameter("@StylistId", newStylist.Id));
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public List<Stylist> GetStylists()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylist. * FROM specialties
      JOIN stylistSpecialties ON (specialties.id = stylistSpecialties.specialtyId)
      JOIN stylist ON (stylistSpecialties.stylistId = stylist.id)
      WHERE specialties.id = @SpecialtyId;";
      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", _specialtyId));
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistTitle = rdr.GetString(1);
        Stylist stylist = new Stylist(stylistTitle, stylistId);
        stylists.Add(stylist);
      }
      conn.Close();
      if (conn != null){conn.Dispose();}
      return stylists;
    }
  }
}
