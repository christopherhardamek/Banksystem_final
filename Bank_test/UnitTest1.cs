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
        var c = new  Customer("Peter","Lastname",12,12,2000,5000,false,0,false,0,12345678);
        Assert.IsFalse(c.IsSenior);
    }
}