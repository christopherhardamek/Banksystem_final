using NUnit.Framework;

namespace Banksystem;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    // [Test]
    // public void getBalance()
    // {
    //     Customer customer = new Customer(0,"Peter", "Nachname",22,12,1960,200,true,200,false);
    //     customer.MakeDeposit(200);
    //     Assert.AreEqual(50, customer.CheckingBalance);

    // }
    // [Test]
    // public void GetName()
    // {
    //     Customer customer = new Customer(0,"Peter", "Nachname",22,12,1960,200,true,200,false);
    //     Assert.AreEqual("Peter", customer.Name);
    // }
    // [Test]
    // public void GetYear()
    // {
    //     Customer customer = new Customer(0,"Peter", "Nachname",22,12,1960,200,true,200,false);
    //     Assert.AreEqual(1920, customer.Birthdate.Year);
    // }
    [Test]
    public void CustomerIsNotSeniorCitizen()
    {
        var c = new Customer("Peter", "Lastname", 12, 12, 2000, 5000, false, 0, false, 0, 12345678);
        Assert.IsFalse(c.IsSenior);
    }

    [Test]
    public void IsCustomerYoungerTheFuture()
    {
        var c = new Customer("Peter", "Lastname", 12, 12, 2000, 5000, false, 0, false, 0, 12345678);
        Assert.IsTrue(c.IsYounger);
    }
    [Test]
    public void GetRightAccountnumber()
    {
        Customer customer = new Customer("Peter", "Lastname", 12, 12, 2000, 5000, false, 0, false, 0, 12345678);
        Assert.AreEqual(12345678, customer.AccountNumber);
    }
    [Test]
    public void getID()
    {
        Customer c1 = new Customer("PEter", "Lastname", 12, 12, 2000, 5000, false, 0, false, 0, 12345678);
        Customer c2 = new Customer("Michael", "Sure", 12, 12, 2000, 5000, false, 0, false, 0, 12345678);
        Assert.AreNotEqual(true,c1.ID==c2.ID);

    }
    public void  CreateSavingAccount()
    {
        Customer c1 = new Customer("PEter", "Lastname", 12, 12, 2000, 5000, false, 0, false, 0, 12345678);
        c1.MakeSavingAccount();
        Assert.IsTrue(true);
        
    }
    
}