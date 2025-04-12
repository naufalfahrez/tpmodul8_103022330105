using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    private static string configFilePath = "covid_config.json";

    public static CovidConfig LoadConfig()
    {
        string json = File.ReadAllText(configFilePath);
        return JsonSerializer.Deserialize<CovidConfig>(json);
    }

    public static void SaveConfig(CovidConfig config)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(config, options);
        File.WriteAllText(configFilePath, json);
    }

    public void UbahSatuan()
    {
        satuan_suhu = satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
        SaveConfig(this);
    }
}
