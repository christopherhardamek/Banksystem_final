using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Banksystem;
public class logging
{
    static public List<Account> logs { get; set; } = new();

    public static void LoadLog()
    {
        if (File.Exists("../logs.json"))
        {
            var json = File.ReadAllText("../logs.json");
            logs = JsonSerializer.Deserialize<List<Account>>(json);
        }
        else
        {
            logs = new List<Account>();
            var json = JsonSerializer.Serialize(logs);
            File.WriteAllText("../logs.json", json);
        }
    }
    public static void Savelog()
    {
        var json = JsonSerializer.Serialize(logs);
        File.WriteAllText("../logs.json", json);
    }
}