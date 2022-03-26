namespace Banksystem;

public class CheckingAccount : Account
{
    int balance;
    public CheckingAccount(Customer owner) : base(owner)
    {
        
    }
    public void PayInfund(int amount)
    {
        balance = balance + amount;
    }

}