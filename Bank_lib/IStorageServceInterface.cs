namespace Banksystem;

public interface IStorageService
{
    public void SaveAccounts(IEnumerable<Account> accounts);
    public IEnumerable<Account> LoadAccounts();
}

