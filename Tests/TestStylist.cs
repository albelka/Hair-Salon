using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      Stylist firstStylist = new Stylist("Frieda", "MWF", 1);
      Stylist secondStylist = new Stylist("Frieda", "MWF", 1);

      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Stylist newStylist = new Stylist("Frieda", "MWF", 1);

      newStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{newStylist};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Stylist newStylist = new Stylist("Frieda", "MWF", 1);

      newStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.Id;
      int testId = newStylist.Id;

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsStylistInDatabase()
    {
      Stylist newStylist = new Stylist("Frieda", "MWF", 1);

      newStylist.Save();
      Stylist foundStylist = Stylist.Find(newStylist.Id);

      Assert.Equal(newStylist, foundStylist);
    }
    [Fact]
    public void Test_GetClients_RetrievesAllClientsWithStylist()
    {
      Stylist newStylist = new Stylist("Frieda", "MWF", 1);
      newStylist.Save();
      Client firstClient = new Client("Mrs. C", newStylist.Id, 1);
      firstClient.Save();
      Client secondClient = new Client("Mr. X", newStylist.Id, 1);
      secondClient.Save();

      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = newStylist.GetClients();

      Assert.Equal(testClientList, resultClientList);
    }

    [Fact]
    public void Test_UpdateName_UpdatesStylistNameInDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Frieda", "MWF", 1);
      testStylist.Save();
      string newName = "Fantastic Frieda";

      //Act
      testStylist.UpdateName(newName);

      string result = testStylist.Name;

      //Assert
      Assert.Equal(newName, result);
    }
    [Fact]
    public void Test_Delete_DeletesStylistFromDatabase()
    {
      //Arrange
      Stylist testStylist = new Stylist("Frieda", "MWF", 1);
      testStylist.Save();

      Stylist testStylist2 = new Stylist("Jimmy", "MWF", 1);
      testStylist2.Save();

      testStylist.Delete();

      List<Stylist> resultList = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist2};
      
      Assert.Equal(testList, resultList);

    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();

    }
  }
}
