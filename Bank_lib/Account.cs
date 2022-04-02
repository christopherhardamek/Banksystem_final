namespace Banksystem
{
    public class Account
    {
        public Customer Owner { get; set; }

        public Account(Customer owner)
        {
            Owner = owner;
        }
    }
}