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
    public bool Credit { get; set; }
    public decimal SavingBalance { get; set; }
    public string log { get; set; }
    public decimal creditamount { get; set; }
    public int ID { get; set; }
    static int nextID = 1;
    public int AccountNumber { get; set; }

    public Customer(string name, string LastName,
    int day, int month, int year, decimal CheckingBalance,
    bool Savingaccount, decimal SavingBalance, bool Credit,
    decimal creditamount, int Accountnumber)
    {
        GetID();
        ValidateLastName(LastName);
        ValidateName(name);
        savingaccount = Savingaccount;

        Birthdate = new DateTime(year, month, day);
        this.savingaccount = Savingaccount;
        this.CheckingBalance = CheckingBalance;
        this.SavingBalance = SavingBalance;
        this.Credit = Credit;
        GetAccountNumber(Accountnumber);

    }
    public Customer() { }


    public void MakeAccount(int ID, string name, string LastName,
                            int day, int month, int year,
                            decimal Checkingbalance, bool Savingaccount,
                            decimal savingBalance, decimal creditamount)
    {

        Customer customer = new Customer(name, LastName,
                                        day, month, year, Checkingbalance,
                                        Savingaccount, savingBalance, Credit,
                                        creditamount, AccountNumber);
        var account = new Account(customer);
        GetID();
        logging.logs.Add($"Added account for  with the ID: {ID} with {name} on {DateTime.Now}");
        logging.Savelog();
        Bank.Accounts.Add(account);
        Bank.SaveAccounts();
    }

    public bool IsSenior => Birthdate < DateTime.Today.AddYears(-45);
    public bool IsYounger => Birthdate < DateTime.Now;

    public void ValidateLastName(string LastName)
    {
        try
        {
            int.Parse(LastName);
            throw new AccountNameInvalid();
        }
        catch (AccountNameInvalid)
        {
            throw;
        }
        catch { }
        var AccountName = LastName.ToString().Length;
        if (AccountName <= 1)
        {
            throw new AccountNameInvalid();

        }
        else if (string.IsNullOrWhiteSpace(LastName))
        {
            throw new AccountNameInvalid();
        }
        else
        {
            Lastname = LastName;
        }
    }

    public void ValidateName(string name)
    {
        try
        {
            int.Parse(name);
            throw new AccountNameInvalid();
        }
        catch (AccountNameInvalid)
        {
            throw;
        }
        catch { }
        var AccountName = name.ToString().Length;
        if (AccountName <= 1)
        {
            throw new AccountNameInvalid();

        }
        else if (string.IsNullOrWhiteSpace(name))
        {
            throw new AccountNameInvalid();
        }
        else
        {
            Name = name;
        }
    }

    public void MakeDeposit(decimal depositAmount)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {

                customer.Owner.CheckingBalance += depositAmount;
                log = $"The user with the ID: {ID} adding money {depositAmount} to {Name} new Balance: {CheckingBalance} on {DateTime.Now}";
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
                    log = $"The user with the ID: {ID} substract money {depositAmount} to {Name} new Balance: {CheckingBalance} on {DateTime.Now}";
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
                logging.logs.Add($"The user with the  ID: {ID} savingaccount created for {Name} on {DateTime.Now}");
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
                    logging.logs.Add($"The user with the {ID} money transfered from Checking to saving new Balance {CheckingBalance}");
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
                    logging.logs.Add($"The user with the {ID} money Transfered from Saving to Checking new Balance {CheckingBalance}");
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
                customer.Owner.creditamount = money;
                Credit = true;
                customer.Owner.CheckingBalance += money;
                logging.logs.Add($"The user with the {ID}  get the credit in High of {money} added to the Checkingbalance");
                logging.Savelog();
            }
        }
        Bank.SaveAccounts();

    }
    public void PayBackCredit(decimal money)
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                if ((customer.Owner.CheckingBalance - money) >= 0)
                {
                    customer.Owner.CheckingBalance -= money;
                    customer.Owner.creditamount = 0;
                    logging.logs.Add($"The credit in High of {money} substracted from the Checkingbalance");
                    logging.Savelog();
                    Credit = false;
                }
            }
        }
        Bank.SaveAccounts();
    }

    public void GetID()
    {
        ID = nextID++;
    }
    public void GetAccountNumber(int Accountnumber)
    {
        var AccountNumberLength = Accountnumber.ToString().Length;
        if (AccountNumberLength >= 8 && AccountNumberLength <= 12)
        {
            AccountNumber = Accountnumber;
        }
        else
        {
            throw new AccountNumberMustBeBetweenn8And12Digits();
        }

    }
    public void GetAge()
    {
        foreach (var customer in Bank.Accounts)
        {
            if (customer.Owner.Name == Name)
            {
                customer.Owner.Age =  DateTime.Today.Year - Birthdate.Year;
                
            }
            Bank.SaveAccounts();
        }
    }
}






// using System.Text.Json;
// using System.Text.Json.Serialization;

// using System;
// using System.IO;

// namespace Banksystem;
// public class Customer : IValidate
// {
//     public string Name { get; set; }
//     public string Lastname { get; set; }
//     public int Age { get; set; }
//     public DateTime Birthdate { get; set; }
//     public decimal CheckingBalance { get; set; }
//     public bool savingaccount { get; set; }
//     public bool Credit { get; set; }
//     public decimal SavingBalance { get; set; }
//     public string log { get; set; }
//     public decimal creditamount { get; set; }
//     public int ID { get; set; }
//     static int nextID = 1;
//     public int AccountNumber { get; set; }

//     private List<Account> accounts;
//     private readonly IStorageService storageService;
//     public IEnumerable<Account> Accounts => accounts;
//     public Customer(IStorageService storageService)
//     {
//         accounts = new List<Account>();
//         this.storageService = storageService;
//     }




//     public Customer(string name, string LastName,
//     int day, int month, int year, decimal CheckingBalance,
//     bool Savingaccount, decimal SavingBalance, bool Credit,
//     decimal creditamount, int Accountnumber)
//     {
//         GetID();
//         ValidateLastName(LastName);
//         ValidateName(name);
//         savingaccount = Savingaccount;

//         Birthdate = new DateTime(year, month, day);
//         this.savingaccount = Savingaccount;
//         this.CheckingBalance = CheckingBalance;
//         this.SavingBalance = SavingBalance;
//         this.Credit = Credit;
//         GetAccountNumber(Accountnumber);

//     }
//     public Customer() { }


//     public void MakeAccount(int ID, string name, string LastName,
//                             int day, int month, int year,
//                             decimal Checkingbalance, bool Savingaccount,
//                             decimal savingBalance, decimal creditamount)
//     {

//         Customer customer = new Customer(name, LastName,
//                                         day, month, year, Checkingbalance,
//                                         Savingaccount, savingBalance, Credit,
//                                         creditamount, AccountNumber);
//         var account = new Account(customer);
//         GetID();
//         logging.logs.Add($"Added account for  with the ID: {ID} with {name} on {DateTime.Now}");
//         logging.Savelog();
//         storageService.SaveAccounts(accounts);
//     }

//     public bool IsSenior => Birthdate < DateTime.Today.AddYears(-45);
//     public bool IsYounger => Birthdate < DateTime.Now;


//     public void ValidateLastName(string LastName)
//     {
//         try
//         {
//             int.Parse(LastName);
//             throw new AccountNameInvalid();
//         }
//         catch (AccountNameInvalid)
//         {
//             throw;
//         }
//         catch { }
//         var AccountName = LastName.ToString().Length;
//         if (AccountName <= 1)
//         {
//             throw new AccountNameInvalid();

//         }
//         else if (string.IsNullOrWhiteSpace(LastName))
//         {
//             throw new AccountNameInvalid();
//         }
//         else
//         {
//             Lastname = LastName;
//         }
//     }

//     public void ValidateName(string name)
//     {
//         try
//         {
//             int.Parse(name);
//             throw new AccountNameInvalid();
//         }
//         catch (AccountNameInvalid)
//         {
//             throw;
//         }
//         catch { }
//         var AccountName = name.ToString().Length;
//         if (AccountName <= 1)
//         {
//             throw new AccountNameInvalid();

//         }
//         else if (string.IsNullOrWhiteSpace(name))
//         {
//             throw new AccountNameInvalid();
//         }
//         else
//         {
//             Name = name;
//         }
//     }

//     public void MakeDeposit(decimal depositAmount)
//     {
//         foreach (var customer in accounts)
//         {
//             if (customer.Owner.Name == Name)
//             {

//                 customer.Owner.CheckingBalance += depositAmount;
//                 log = $"The user with the ID: {ID} adding money {depositAmount} to {Name} new Balance: {CheckingBalance} on {DateTime.Now}";
//                 storageService.SaveAccounts(accounts);
//                 break;
//             }
//         }
//         storageService.SaveAccounts(accounts);
//         logging.logs.Add(log);
//         logging.Savelog();
//     }
//     public void Withdrawn(decimal depositAmount)
//     {
//         foreach (var customer in accounts)
//         {
//             if (customer.Owner.Name == Name)
//             {
//                 if ((customer.Owner.CheckingBalance - depositAmount) >= -500)
//                 {
//                     customer.Owner.CheckingBalance -= depositAmount;
//                     log = $"The user with the ID: {ID} substract money {depositAmount} to {Name} new Balance: {CheckingBalance} on {DateTime.Now}";
//                     logging.logs.Add(log);
//                     logging.Savelog();
//                 }
//                 break;
//             }
//         }
//     }
//     public void MakeSavingAccount()
//     {
//         foreach (var customer in accounts)
//         {
//             if (customer.Owner.Name == Name)
//             {
//                 customer.Owner.savingaccount = true;
//                 storageService.SaveAccounts(accounts);
//                 logging.logs.Add($"The user with the  ID: {ID} savingaccount created for {Name} on {DateTime.Now}");
//                 logging.Savelog();
//                 break;
//             }
//         }
//         storageService.SaveAccounts(accounts);
//     }
//     public async void TransferMoneyFromCheckingToSaving(decimal deposit)
//     {
//         foreach (var customer in Accounts)
//         {
//             if (customer.Owner.Name == Name)
//             {
//                 if ((customer.Owner.CheckingBalance - deposit) >= -500)
//                 {
//                     customer.Owner.CheckingBalance -= deposit;
//                     customer.Owner.SavingBalance += deposit;
//                     logging.logs.Add($"The user with the {ID} money transfered from Checking to saving new Balance {CheckingBalance}");
//                     break;
//                 }

//             }
//             storageService.SaveAccounts(accounts);

//         }
//     }
//     public void TransferMoneyFromSavingToChecking(decimal deposit)
//     {
//         foreach (var customer in accounts)
//         {
//             if (customer.Owner.Name == Name)
//             {
//                 if ((customer.Owner.SavingBalance - deposit) >= 0)
//                 {
//                     customer.Owner.CheckingBalance += deposit;
//                     customer.Owner.SavingBalance -= deposit;
//                     storageService.SaveAccounts(accounts);
//                     logging.logs.Add($"The user with the {ID} money Transfered from Saving to Checking new Balance {CheckingBalance}");
//                     break;
//                 }
//             }
//         }
//         storageService.SaveAccounts(accounts);
//     }
//     public void getCredit(decimal money)
//     {
//         foreach (var customer in Accounts)
//         {
//             if (customer.Owner.Name == Name)
//             {
//                 customer.Owner.creditamount = money;
//                 Credit = true;
//                 customer.Owner.CheckingBalance += money;
//                 logging.logs.Add($"The user with the {ID}  get the credit in High of {money} added to the Checkingbalance");
//                 logging.Savelog();
//             }
//         }
//         storageService.SaveAccounts(accounts);

//     }
//     public void PayBackCredit(decimal money)
//     {
//         foreach (var customer in Accounts)
//         {
//             if (customer.Owner.Name == Name)
//             {
//                 if ((customer.Owner.CheckingBalance - money) >= 0)
//                 {
//                     customer.Owner.CheckingBalance -= money;
//                     customer.Owner.creditamount = 0;
//                     logging.logs.Add($"The credit in High of {money} substracted from the Checkingbalance");
//                     logging.Savelog();
//                     Credit = false;
//                 }
//             }
//         }
//         storageService.SaveAccounts(accounts);
//     }

//     public void GetID()
//     {
//         ID = nextID++;
//     }
//     public void GetAccountNumber(int Accountnumber)
//     {
//         var AccountNumberLength = Accountnumber.ToString().Length;
//         if (AccountNumberLength >= 8 && AccountNumberLength <= 12)
//         {
//             AccountNumber = Accountnumber;
//         }
//         else
//         {
//             throw new AccountNumberMustBeBetweenn8And12Digits();
//         }

//     }
//     // public void GetAge()
//     // {
//     //     foreach (var customer in Accounts)
//     //     {
//     //         if (customer.Owner.Name == Name)
//     //         {
//     //             accounts =  customer.Owner.
//     //             storageService.SaveAccounts(accounts);
//     //         }
//     //     }
//     // }
// }

