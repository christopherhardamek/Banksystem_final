using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Banksystem;
public static class Bank
{
    static public List<Account> Accounts { get; set; } = new();
    
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