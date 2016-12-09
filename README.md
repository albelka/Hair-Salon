# Hair Salon

#### The program enables the owner of a hair salon to add to a list of stylists to a database and for each stylist, add clients who see that stylist, 12.02.16.

#### By **Anne Belka**

### Specifications

* Behavior: The program can add a stylist to a list.
* Input: "Frieda"
* Output: "Frieda"

* Behavior: The program can display a list of stylists.
* Input: "Frieda", "Becky"
* Output: "Frieda, Becky"

* Behavior: The program can display a particular stylist and their details including their clients.
* Input: "Frieda"
* Output: "Frieda, Available: MWF, Clients: Mrs. C, Mr. X"

* Behavior: The program can add a new client to a specific stylist.
* Input: "Frieda, new client: Mr Y"
* Output: "Frieda, Available: MWF, Clients: Mrs. C, Mr. X, Mr. Y"

* Behavior: The program can update a stylists details.
* Input: "Frieda new availability: MWFSa"
* Output: "Frieda, Available: MWFSa, Clients: Mrs. C, Mr. X, Mr. Y"

* Behavior: The program can delete a stylist.
* Input: Delete "Frieda"
* Output: List of stylists: "Becky"

* Behavior: The program can delete a client.
* Input: Delete "Mr. Y"
* Output: "Frieda, Available: MWFSa, Clients: Mrs. C, Mr. X"


## Setup/Installation Requirements
* In SQLCMD:
CREATE DATABASE hair_salon;
GO
USE hair_salon;
GO
CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255));
CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), availability VARCHAR(255));
GO

* Clone this repository or download it to your computer.
* Navigate to the project directory in the terminal.
* Use the command > dnu restore to download any necessary dependencies.
* Use the command > dnx kestrel to run the project on the local server.
* Navigate to localhost:5004 in your browser to view the app.

### License

GPL

Copyright (c) 2016 **_Anne Belka_**
