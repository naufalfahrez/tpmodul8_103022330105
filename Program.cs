using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        config.UbahSatuan(); 

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        string inputSuhu = Console.ReadLine();
        double suhu;
        while (!double.TryParse(inputSuhu, out suhu))
        {
            Console.Write("Input tidak valid. Masukkan kembali suhu badan anda: ");
            inputSuhu = Console.ReadLine();
        }

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        string inputHari = Console.ReadLine();
        int hari;
        while (!int.TryParse(inputHari, out hari))
        {
            Console.Write("Input tidak valid. Masukkan kembali jumlah hari: ");
            inputHari = Console.ReadLine();
        }

        bool suhuNormal = false;
        if (config.satuan_suhu == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        if (suhuNormal && hari >= config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}
