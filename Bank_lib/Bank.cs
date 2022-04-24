using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Banksystem;
public static class Bank
{
    public static List<Account> Accounts { get; set; } = new();
    
    public static void LoadAccounts()
    {
        if (File.Exists("../accounts.json"))
        {
            var json = File.ReadAllText("../accounts.json");
            Accounts = JsonSerializer.Deserialize<List<Account>>(json);
        }else
        {
            Accounts= new List<Account>();
            var json = JsonSerializer.Serialize(Accounts);
            File.WriteAllText("../accounts.json", json);
        }
    }
    public static void SaveAccounts()
    {
        var json = JsonSerializer.Serialize(Accounts);
        File.WriteAllText("../accounts.json", json);
    }
    

}




// using System.Collections.Generic;
// using System.IO;
// using System.Text.Json;

// namespace Banksystem;
// public class Bank
// {
//     private List<Account> accounts;
//     private readonly IStorageService storageService;
//     public IEnumerable<Account> Accounts => accounts;
//     public Bank(IStorageService storageService)
//     {
//         accounts = new List<Account>();
//         this.storageService = storageService;
//     }

//     public void SaveAccounts()
//     {
//         storageService.SaveAccounts(accounts);
//     }

//     public void LoadAccounts()
//     {
//         accounts.AddRange(storageService.LoadAccounts());
//     }
// }