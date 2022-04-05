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
    public decimal Balance { get; set; }
    public bool savingaccount;
    public string log;


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
        var account  = new  Account(customer);
        Bank.Accounts.Add(account);
        Bank.SaveAccounts();
        logging.logs.Add($"Added account for {name} on {DateTime.Now}");
        logging.Savelog();
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
            throw new Exception("Name too short");

        }
        else
        {
            Name = name;
            return true;
        }
    }
    public void MakeDeposit(decimal depositAmount)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                customer.Owner.Balance += depositAmount;
                break;
            }
        }
        Console.WriteLine($"Adding money {depositAmount} to {Name}");

        this.Balance += depositAmount;
    }
    public void Withdrawn(decimal depositAmount)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                if ((customer.Owner.Balance - depositAmount) >= -500)
                {
                    customer.Owner.Balance -= depositAmount;

                }
            break;
            }
        }
        Console.WriteLine($"Subract money {depositAmount} to {Name}");
    }
}