using System.Text.Json;
using System.Text.Json.Serialization;

using System;
using System.IO;

namespace Banksystem;
public class Customer : IValidate
{
    public string Name{get;set;}
    public string Lastname { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public decimal Balance{get;private set;} = 0;
    public bool savingaccount;



    private List<Account> accounts = new();
    public IEnumerable<Account> Accounts => accounts;
    public Customer(string name, string LastName, int day, int month, int year, bool savingaccount,decimal amount)
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
        this.savingaccount = savingaccount;

    }
    public Customer(){}

    public void MakeAccount(string name, string LastName, int day, int month, int year, decimal amount)
    {
        Customer customer = new Customer(name, LastName, day, month, year,savingaccount, amount);
        var json = JsonSerializer.Serialize(customer);
        File.WriteAllText("../accounts.json", json);
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