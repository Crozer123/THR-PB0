
class Program
{
    static void Main()
    {
        Console.WriteLine("=== SISTEM MANAJEMEN KARYAWAN ===");
        Console.Write("Masukkan jenis karyawan (tetap/kontrak/magang): ");
        string jenis = Console.ReadLine();

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        if (jenis == "tetap")
            karyawan = new KaryawanTetap(nama, id, gajiPokok);
        else if (jenis == "kontrak")
            karyawan = new KaryawanKontrak(nama, id, gajiPokok);
        else if (jenis == "magang")
            karyawan = new KaryawanMagang(nama, id, gajiPokok);
        else
        {
            Console.WriteLine("Jenis karyawan tidak valid.");
            return;
        }

        karyawan.Nama = nama;
        karyawan.ID = id;
        karyawan.GajiPokok = gajiPokok;

        Console.WriteLine("\n=== RINCIAN GAJI ===");
        Console.WriteLine($"Nama      : {karyawan.Nama}");
        Console.WriteLine($"ID        : {karyawan.ID}");
        Console.WriteLine($"Gaji Akhir: {karyawan.HitungGaji()}");
    }
}
class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;
    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }
    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }
    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    private double bonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GajiPokok + bonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    private double potonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GajiPokok - potonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GajiPokok;
    }
}
