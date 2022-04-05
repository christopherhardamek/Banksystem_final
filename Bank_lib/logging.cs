using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Banksystem;
public class logging
{
    static public List<string> logs { get; set; } = new();

    public static void LoadLog()
    {
        if (File.Exists("../logs.json"))
        {
            var json = File.ReadAllText("../logs.json");
            logs = JsonSerializer.Deserialize<List<string>>(json);
        }
        else
        {
            logs = new List<string>();
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