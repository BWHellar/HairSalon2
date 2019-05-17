# Hair Salon
#### This Project will be a mock up of a hair salon database, May/12/2019


#### By _**Brendan Hellar**_

## Description


#### This project is focused on introductory database mechanics.  This will showcase our understanding of both C# and SQL database.  The project will be constructing a fake hair salon website complete with a database of both stylists and clients for each stylist.

## Specs
| Spec | Input | Output | Reasoning |
| :-------------     | :------------- | :------------- | :----------- |
| **Allows for input of new Stylists into database** | User input: "Bob" | Output: "Bob" | Reasoning: The user inputs Bob into the input and it saves the name into the database. |
| **Allows for owner to see stylists** | User Input: "Bob" | Output: "Bob" | Reasoning: Once the owner logs a new stylist the stylists name will show up on the screen as well. |
| **Allows for Clients to be added to database** | User Input: "Jenny" | Output: "Jenny" | Reasoning: Once a client is created they are then allowed to select a Stylist to attach to. |
| **Allows for Stylist to see current clients** | User Input: "Jenny" | Output: "Jenny" | Reasoning: The program will pull the Client database for that particular Stylist |
| **Allows for Specialties to be added and attached to Stylists** | User Input: "Trimming" | Output: "Jenny" | Reasoning: When Specialties are added it will allow you to attched them to a stylist. |

###### Here we allow for the Owner to save new Stylists to the database.  With this Save function we are able to open the Sql connection and insert a new person into the database under Stylists.  The functionality for saving Clients is more or less the same idea.
```

==============
 ```

 ###### This will allow us to gather all the Stylists from our database in order to show them to the Owner.  It pulls from the database we have and displays the ones that are currently logged in to it.  The functionality for Clients works more or less the same in terms of idea.

 ```
 
=======
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
