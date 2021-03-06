using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Client.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      Client firstClient = new Client("Mrs. C", 1, 1);
      Client secondClient = new Client("Mrs. C", 1, 1);

      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Client newClient = new Client("Mrs. C", 1, 1);

      newClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{newClient};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Client newClient = new Client("Mrs. C", 1, 1);

      newClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.Id;
      int testId = newClient.Id;

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsClientInDatabase()
    {
      Client newClient = new Client("Mrs. C", 1, 1);
      newClient.Save();
      Client foundClient = Client.Find(newClient.Id);

      Assert.Equal(newClient, foundClient);
    }
    [Fact]
    public void Test_Delete_DeletesClientFromDatabase()
    {
      Client newClient = new Client("Mrs. C", 1, 1);
      Client nextClient = new Client("Mrs. Y", 1, 1);
      newClient.Save();
      nextClient.Save();
      nextClient.Delete();

      List<Client> allClients = Client.GetAll();
      List<Client> result = new List<Client> {newClient};

      Assert.Equal(result, allClients);
    }
    [Fact]
    public void Test_UpdateName_UpdatesClientNameInDatabase()
    {
      //Arrange
      Client testClient = new Client("Mrs. C", 1, 1);
      testClient.Save();
      string newName = "Mrs. Cauliflower";

      //Act
      testClient.UpdateName(newName);

      string result = testClient.Name;

      //Assert
      Assert.Equal(newName, result);
    }
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }


  }
}
