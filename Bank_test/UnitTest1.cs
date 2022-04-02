using NUnit.Framework;

namespace Banksystem;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void getBalance()
    {
        Customer customer = new Customer("Peter", "Nachname", 22, 12, 1920, 50);
        Assert.AreEqual(50, customer.Balance);
    }
    [Test]
    public void GetName()
    {
        Customer customer = new Customer("Peter", "Nachname", 22, 12, 1920, 50);
        Assert.AreEqual("Peter", customer.Name);
    }
    [Test]
    public void GetYear()
    {
        Customer customer = new Customer("Peter", "Nachname", 22, 12, 1920, 50);
        Assert.AreEqual(1920, customer.Birthdate.Year);
    }
}