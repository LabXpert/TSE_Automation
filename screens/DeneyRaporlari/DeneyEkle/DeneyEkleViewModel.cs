using System.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TSE_Automation.ViewModels;

public partial class DeneyBilgisi : ObservableObject
{
    [ObservableProperty]
    private string? deneyTuru;

    [ObservableProperty]
    private string? sorumluPersonel;

    [ObservableProperty]
    private bool akredite;
}

public partial class DeneyEkleViewModel : ViewModelBase
{
        // SQL'den doldurulacak firma listesi (şimdilik örnek)
    public ObservableCollection<string> Firmalar { get; } = new() { "Firma A", "Firma B" };

    public ObservableCollection<string> DeneyTurleri { get; } = new()
    {
        "ÇEKME","KİMYASAL","ROCKWELL","BRİNELL","ÇENTİK","VİCKERS",
        "KAPLAMA KALINLIĞI","BOYUT ÖLÇME","YÜZEY PÜRÜZLÜLÜĞÜ",
        "BOYUTSAL ÖLÇÜM","MİKROYAPI","BUHAR GERİ KAZANIM"
    };

    public ObservableCollection<string> Personeller { get; } = new()
    {        "ALİ DESDİ","MUHAMMED BÜLBÜL","BURAK DERELİOĞLU"
    };

    [ObservableProperty]
    private string? seciliFirma;

    [ObservableProperty]
    private string? basvuruNo;

    [ObservableProperty]
    private DateTimeOffset basvuruTarihi = DateTimeOffset.Now;

    [ObservableProperty]
    private bool ozel;

    [ObservableProperty]
    private bool belgelendirme;

    [ObservableProperty]
    private int deneySayisi = 1;

    public ObservableCollection<DeneyBilgisi> DeneyGirdileri { get; } = new();

    // Son 5 kayıt için placeholder
    public ObservableCollection<object> SonKayitlar { get; } = new();

    public DeneyEkleViewModel()
    {
        DeneyGirdileri.Add(new DeneyBilgisi());

        // Örnek son kayıtlar ekle
        SonKayitlar.Add(new { 
            FirmaAdi = "Örnek Firma A", 
            BasvuruNo = "TSE-2024-001", 
            BasvuruTarihi = DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"), 
            DeneySayisi = 2 
        });
        SonKayitlar.Add(new { 
            FirmaAdi = "Örnek Firma B", 
            BasvuruNo = "TSE-2024-002", 
            BasvuruTarihi = DateTime.Now.AddDays(-3).ToString("dd.MM.yyyy"), 
            DeneySayisi = 1 
        });
        SonKayitlar.Add(new { 
            FirmaAdi = "Örnek Firma C", 
            BasvuruNo = "TSE-2024-003", 
            BasvuruTarihi = DateTime.Now.AddDays(-7).ToString("dd.MM.yyyy"), 
            DeneySayisi = 3 
        });

        PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(DeneySayisi))
            {
                while (DeneyGirdileri.Count < DeneySayisi)
                    DeneyGirdileri.Add(new DeneyBilgisi());
                while (DeneyGirdileri.Count > DeneySayisi)
                    DeneyGirdileri.RemoveAt(DeneyGirdileri.Count - 1);
            }
        };
    }

    [RelayCommand]
    private void Kaydet()
    {
        // Zorunlu alan kontrolü
        if (SeciliFirma is null ||
            string.IsNullOrWhiteSpace(BasvuruNo) ||
            DeneyGirdileri.Any(d =>
                string.IsNullOrWhiteSpace(d.DeneyTuru) ||
                string.IsNullOrWhiteSpace(d.SorumluPersonel)))
        {
            // TODO: Kullanıcıya uyarı göster
            return;
        }

        // TODO: SQL bağlantısı ile verileri kaydet
        /*
        using (var con = new SqlConnection("connectionString"))
        {
            con.Open();
            // INSERT komutları burada
        }

        // SonKayitlar.Clear();
        // SQL'den son 5 kayıt çek ve SonKayitlar'a ekle
        */

        // Giriş alanlarını sıfırla
        SeciliFirma = null;
        BasvuruNo = string.Empty;
        BasvuruTarihi = DateTimeOffset.Now;
        Ozel = false;
        Belgelendirme = false;
        DeneySayisi = 1;
    }
        [RelayCommand]
    private void FirmaEkle()
    {
        // TODO: FirmaEkleView'e navigasyon
    }
}