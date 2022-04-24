using System.Text.Json;
using Banksystem;

public class JsonStorageService : IStorageService
{
   public IEnumerable<Account> LoadAccounts()
    {
        List<Account> accounts = new();
        if(File.Exists("accounts.json"))
        {
            var json = File.ReadAllText("accounts.json");
            accounts = System.Text.Json.JsonSerializer.Deserialize<List<Account>>(json);
        }
        return accounts;
    }

    public void SaveAccounts(IEnumerable<Account> accounts)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(accounts);
        File.WriteAllText("accounts.json", json);
    }
}