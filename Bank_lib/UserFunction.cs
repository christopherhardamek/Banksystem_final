namespace Banksystem;
public class UserFunctions
{
    public int amount;

    public void Deposit(int amount, int balance)
    {
        if(balance - amount >=-500)
        {
            balance = balance - amount;
        }else{
            Console.WriteLine("Insuffient funds");
        }
    }
    public void TransferMoneyOnAccounts()
    {
        
    }

}