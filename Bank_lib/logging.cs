using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Banksystem;
public class logging
{
    static public List<string> logs { get; set; } = new();

    public static void LoadLog()
    {
        if (File.Exists("../files/logs.json"))
        {
            var json = File.ReadAllText("../files/logs.json");
            logs = JsonSerializer.Deserialize<List<string>>(json);
        }
        else
        {
            logs = new List<string>();
            var json = JsonSerializer.Serialize(logs);
            File.WriteAllText("../files/logs.json", json);
        }
    }
    public static void Savelog()
    {
        var json = JsonSerializer.Serialize(logs);
        File.WriteAllText("../files/logs.json", json);
    }
}