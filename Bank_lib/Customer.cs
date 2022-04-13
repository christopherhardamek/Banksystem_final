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
    public decimal CheckingBalance { get; set; }
    public bool savingaccount { get; set; }
    public bool Credit { get; private set; }
    public decimal SavingBalance { get; set; }
    public string log { get; set; }
    public decimal creditamount { get; set; }


    public Customer(string name, string LastName,
    int day, int month, int year, decimal CheckingBalance,
    bool Savingaccount, decimal SavingBalance, bool Credit)
    {
        if (ValidateLastName(LastName) == true)
        {
            Lastname = LastName;
        }
        if (ValidateName(name))
        {
            Name = name;
        }
        savingaccount = Savingaccount;

        Birthdate = new DateTime(year, month, day);
        this.savingaccount = Savingaccount;
        this.CheckingBalance = CheckingBalance;
        this.SavingBalance = SavingBalance;
        this.Credit = Credit;

    }
    public Customer() { }


    public void MakeAccount(string name, string LastName,
                            int day, int month, int year,
                            decimal Checkingbalance, bool Savingaccount,
                            decimal savingBalance)
    {
        Customer customer = new Customer(name, LastName, day, month, year, Checkingbalance, Savingaccount, savingBalance, Credit);
        var account = new Account(customer);
        logging.logs.Add($"Added account for {name} on {DateTime.Now}");
        logging.Savelog();
        Bank.Accounts.Add(account);
        Bank.SaveAccounts();
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
                customer.Owner.CheckingBalance += depositAmount;
                log = $"Adding money {depositAmount} to {Name} new Balance: {CheckingBalance} on {DateTime.Now}";
                Bank.SaveAccounts();
                break;
            }
        }
        Bank.SaveAccounts();
        logging.logs.Add(log);
        logging.Savelog();
    }
    public void Withdrawn(decimal depositAmount)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                if ((customer.Owner.CheckingBalance - depositAmount) >= -500)
                {
                    customer.Owner.CheckingBalance -= depositAmount;
                    log = $"Substract money {depositAmount} to {Name} new Balance: {CheckingBalance} on {DateTime.Now}";
                    logging.logs.Add(log);
                    logging.Savelog();
                }
                break;
            }
        }
    }
    public void MakeSavingAccount()
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                customer.Owner.savingaccount = true;
                Bank.SaveAccounts();
                logging.logs.Add($"Savingaccount created for {Name} on {DateTime.Now}");
                logging.Savelog();
                break;
            }
        }
        Bank.SaveAccounts();
    }
    public void TransferMoneyFromCheckingToSaving(decimal deposit)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {

                if ((customer.Owner.CheckingBalance - deposit) >= -500)
                {
                    customer.Owner.CheckingBalance -= deposit;
                    customer.Owner.SavingBalance += deposit;
                    logging.logs.Add($"Money Transfered from Checking to Saving new Balance {CheckingBalance}");
                    break;
                }

            }
            Bank.SaveAccounts();

        }
    }
    public void TransferMoneyFromSavingToChecking(decimal deposit)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                if ((customer.Owner.SavingBalance - deposit) >= 0)
                {
                    customer.Owner.CheckingBalance += deposit;
                    customer.Owner.SavingBalance -= deposit;
                    Bank.SaveAccounts();
                    logging.logs.Add($"Money Transfered from Saving to Checking new Balance {CheckingBalance}");
                    break;

                }
            }
        }
        Bank.SaveAccounts();
    }
    public void getCredit(decimal money)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                Credit = true;
                customer.Owner.CheckingBalance += money;
            }
        }

    }
    public void PayBackCredit(decimal money)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                if ((customer.Owner.CheckingBalance - money) >= 0)
                {
                    Credit = false;
                    customer.Owner.CheckingBalance -= money;

                }
            }
        }
    }

}

