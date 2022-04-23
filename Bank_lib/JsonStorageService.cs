using System.Text.Json;
using Banksystem;

public  class JsonStorageService : IStorageService
{
    public static List<Account> Accounts { get; set; } = new();
    IEnumerable<Account> accounts;
    public void SaveAccounts(List<Account> Accounts)
    {
        var json = JsonSerializer.Serialize(Accounts);
        File.WriteAllText("../accounts.json", json);
    }

    Account LoadAccounts()
    {
        if (File.Exists("../accounts.json"))
        {
            var json = File.ReadAllText("../accounts.json");
            Accounts = JsonSerializer.Deserialize<List<Account>>(json);
        }
        else
        {
            Accounts = new List<Account>();
            var json = JsonSerializer.Serialize(Accounts);
            File.WriteAllText("../accounts.json", json);
        }
    }
}
    // public List<Account> LoadAccounts()
    // {

    // }