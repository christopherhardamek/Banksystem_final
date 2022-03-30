namespace Banksystem
{
    public class Account
    {
        public decimal Balance { get; private set; }
        public Customer Owner { get; set; }

        public Account(Customer owner)
        {
            Owner = owner;
        }

        public void MakeDeposit(decimal depositAmount)
        {
            Balance = Balance + depositAmount;
        }
    }
}