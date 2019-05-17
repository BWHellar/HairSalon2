using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    public string Name { get { return _name;} }

    private int _id;
    public int Id { get { return _id;} set { _id = value;} }

    private int _stylistId;
    public int StylistId { get { return _stylistId;} set { _stylistId =value;} }

    public Client (string name, int id = 0, int stylistId = 0)
    {
      _name = name;
      _id = id;
      _stylistId = stylistId;
    }
    
    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client client = (Client) otherClient;
        bool idEquality = (this.Id == client.Id);
        bool nameEquality = (this.Name == client.Name);
        bool stylist_IdEquality = (this.StylistId == client.StylistId);
        return(idEquality && nameEquality && stylist_IdEquality);
      }
    }

    public override int GetHashCode()
    {return this.Id.GetHashCode();}

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM client;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO client (Name, StylistId) VALUES (@name, @stylistId);";
      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@stylistId", _stylistId));
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public static List<Client> GetAll()
    {
      List<Client> allClient = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        int StylistId = rdr.GetInt32(2);
        Client client = new Client(ClientName, StylistId, ClientId);
        allClient.Add(client);
      }
      conn.Close();
      if (conn != null){conn.Dispose();}
      return allClient;
    }

    public static List<Client> GetClientId(int id)
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client WHERE stylistId = @stylistId ;";
      cmd.Parameters.Add(new MySqlParameter("@stylist_Id", id));
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int Id = rdr.GetInt32(0);
        string Name = rdr.GetString(1);
        int StylistId = rdr.GetInt32(2);
        Client client = new Client(Name, StylistId, Id);
        allClients.Add(client);
      }
      conn.Close();
      if (conn != null){conn.Dispose();}
      return allClients;
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int ClientId = 0;
      string ClientName = "";
      int StylistId = 0;
      while(rdr.Read())
      {
        ClientId = rdr.GetInt32(0);
        ClientName = rdr.GetString(1);
        StylistId = rdr.GetInt32(2);
      }
      Client client = new Client(ClientName, StylistId, ClientId);
      conn.Close();
      if (conn != null){conn.Dispose();}
      return client;
    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE client SET Name = @newName WHERE id = @searchId;";
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
     cmd.CommandText = @"DELETE FROM client WHERE id = @thisId;";
     cmd.Parameters.Add(new MySqlParameter("@thisID", _id));
     cmd.ExecuteNonQuery();
     conn.Close();
     if(conn != null){conn.Dispose();}
   }
  }
}
