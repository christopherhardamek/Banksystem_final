using System.Text.Json;
using System.Text.Json.Serialization;

using System;
using System.IO;

namespace Banksystem;
public class Customer : IValidate
{
    public string Name;
    public string Lastname { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public int Balance = 0;

    public string getName()
    {
        return Name;
    }
    public void setName(string name)
    {
        Name = name;
    }
    public int getBalance()
    {
        return Balance;
    }
    private List<Account> accounts;
    public IEnumerable<Account> Accounts => accounts;
    public Customer(string name, string LastName, int day, int month, int year)
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


    }

    public void MakeAccount(string name, string LastName, int day, int month, int year)
    {

        Customer customer = new Customer(name, LastName, day, month, year);
        var json = JsonSerializer.Serialize(customer);
        File.WriteAllText("accounts.json", json);

    }

    public bool ValidateLastName(string LastName)
    {
        if (LastName.Length == 0)
        {
            throw new Exception("Name to short");
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
}