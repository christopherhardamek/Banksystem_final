using System.Text.Json;
using System.Text.Json.Serialization;

using System;
using System.IO;

namespace Banksystem;
public class Customer : IValidate
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public decimal Balance { get; private set; }
    public bool savingaccount;



    private List<Account> accounts = new();
    public IEnumerable<Account> Accounts => accounts;
    public Customer(string name, string LastName, int day, int month, int year, decimal Balance)
    {
        if (ValidateLastName(LastName) == true)
        {
            Lastname = LastName;
        }
        if (ValidateName(name))
        {
            Name = name;
        }

        Birthdate = new DateTime(year, month, day);
        this.Balance = Balance;

    }
    public Customer() { }

    public void MakeAccount(string name, string LastName, int day, int month, int year, decimal Balance)
    {
        Customer customer = new Customer(name, LastName, day, month, year, Balance);
        var json = JsonSerializer.Serialize(customer);
        File.WriteAllText("../accounts.json", json);
    }

    public bool ValidateLastName(string LastName)
    {
        if (LastName.Length == 0)
        {
            throw new Exception("Name too short");
        }
        else
        {
            Lastname = LastName;
            return true;
        }

    }

    public bool ValidateName(string name)
    {
        if (name.Length == 0)
        {
            throw new Exception("Name to short");

        }
        else
        {
            Name = name;
            return true;
        }
    }
    public void MakeDeposit(decimal depositAmount)
    {
        Balance = Balance + depositAmount;
    }
}