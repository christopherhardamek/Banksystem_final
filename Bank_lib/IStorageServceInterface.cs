namespace Banksystem;

public interface IStorageService 
{
    public static List<Account> Accounts { get; set; } = new();
    Account LoadAccounts();
    void SaveAccounts(List<Account> Accounts);
}

