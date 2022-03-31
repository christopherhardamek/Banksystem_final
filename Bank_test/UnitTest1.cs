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
        Customer customer = new Customer("Peter","Nachname",22,12,1920,50);
        Assert.AreEqual(0,customer.Balance);
    }
}