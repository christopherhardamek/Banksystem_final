using System.Text.Json;
using System.Text.Json.Serialization;

using System;
using System.IO;

namespace Banksystem;
public class Customer : IValidate
{
    public string Name{get;set;}
    public string Lastname{get;set;}
    public int Age{get;set;}
    public DateTime Birthdate{get;set;}

    
    public Customer(string name, string LastName, int day, int month, int year)
    {
        Name = name;
        Lastname = LastName;
        Birthdate = new DateTime(year,month,day);
        
    }

    public void MakeAccount(string name, string LastName, int day, int month, int year)
    {
        Customer customer = new Customer(name, LastName, day, month, year);
        var json = JsonSerializer.Serialize(customer);
        File.WriteAllText("accounts.json", json);

    }

        public void ValidateLastName(string LastName)
    {
        if (LastName.Length == 0)
        {
            Console.WriteLine("Name to short");

        }
        else if (LastName == " ")
        {
            Console.WriteLine("Name is empty");
        }
        else
        {
            Lastname = LastName;
        }
    }

    public void ValidateName(string name)
    {
        if (name.Length == 0)
        {
            Console.WriteLine("Name to short");

        }
        else if (name == " ")
        {
            Console.WriteLine("Name is empty");
        }
        else
        {
            Name = name;
        }
    }
}