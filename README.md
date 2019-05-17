# Hair Salon
#### This Project will be a mock up of a hair salon database, May/12/2019


#### By _**Brendan Hellar**_

## Description


#### This project is focused on introductory database mechanics.  This will showcase our understanding of both C# and SQL database.  The project will be constructing a fake hair salon website complete with a database of both stylists and clients for each stylist.

## Specs
| Spec | Input | Output | Reasoning |
| :-------------     | :------------- | :------------- | :----------- |
| **Allows for input of new Stylists into database** | User input: "Bob" | Output: "Bob" | Reasoning: The user can input a Stylist. |
| **Allows for input of new Clients into database** | User input: "Joe" | Output: "Joe" | Reasoning: The user can input a Clients name and attach them to a Stylist. |
| **Allows for input of new Stylists into database** | User input: "Trim" | Output: "Trim" | Reasoning: The user is able to input a Speciality and attach it to a Stylist. |

| **Allows for user to see Stylists** | User Input: "Bob" | Output: "Bob" | Reasoning: Once the owner logs a new Stylist the Stylists name will show up on the view screen. |
| **Allows for user to see Clients** | User Input: "Joe" | Output: "Joe" | Reasoning: Once the owner logs a new Client the Clients name will show up on the view screen. |
| **Allows for user to see Specialities** | User Input: "Trim" | Output: "Trim" | Reasoning: Once the owner logs a new Speciality the Speciality name will show up on the view screen. |

| **Allows for user to edit Client name** | Old User Input: "Jenny" | New User Output: "Bob" | Reasoning: Once a Client is input into the system the user can edit the name. |
| **Allows for user to edit Client name** | Old User Input: "Janny" | New User Output: "Joe" | Reasoning: Once a Stylist is input into the system the user can edit the name. |
| **Allows for user to edit Client name** | Old User Input: "Mirt" | New User Output: "Trim" | Reasoning: Once a Speciality is input into the system the user can edit the name. |

###### Here we have our delete all function which acts similarly to the other models.
```
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
==============
 ```
###### Here we have our save function which acts similarly to the other models.
 ```
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
=============
```
###### Here we have our get all function which acts similarly to the other models.
```
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
==============
 ```
###### Here we have our get all client id function which acts similarly to the other models.
 ```
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
 ==============
```
###### Here we have our find function which acts similarly to the other models.
 ```
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
=============
```
###### Here we have our edit function which acts similarly to the other models.
 ```
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
=============
```
###### Here we have our delete function which acts similarly to the other models.
 ```
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
=============
```
## Setup/Installation Requirements

Download .NET Core 2.2.103 SDK install it. Download Mono and install it.

1. Clone this repository: $ git clone >repo name here<
2. Change into the work directory: $ cd HairSalon.Solution
3. Change into the primary directory: $ cd HairSalon
4. Input $ dotnet build
5. Input $ dotnet run
6. Navigate to http://localhost:5000 on the web browser of your choosing.


## Known Bugs

No known bugs

## Support and contact details

If you have any issues please contact Brendan Hellar at bwhellar@gmail.com

## Technologies Used

C#, SQL server through MAMPS

### License

MIT

Copyright (c) 2019 **Brendan Hellar**
