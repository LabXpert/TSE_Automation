using System.Collections.ObjectModel;
using System.ComponentModel;
using TSE_Automation.Models;

namespace TSE_Automation.ViewModels
{
    public class FirmaEkleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Firma> _sonEklenenFirmalar;

        public ObservableCollection<Firma> SonEklenenFirmalar
        {
            get => _sonEklenenFirmalar;
            set
            {
                _sonEklenenFirmalar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SonEklenenFirmalar)));
            }
        }

        public FirmaEkleViewModel()
        {
            _sonEklenenFirmalar = new ObservableCollection<Firma>();
            
            // Test verileri - gerçek uygulamada database'den gelecek
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Örnek firmalar
            SonEklenenFirmalar.Add(new Firma
            {
                Id = 1,
                FirmaAdi = "ABC Teknoloji A.Ş.",
                Telefon = "0312 123 45 67",
                VergiNumarasi = "1234567890",
                Yetkili = "Ahmet Yılmaz",
                Adres = "Çankaya/Ankara",
                EklenmeTarihi = System.DateTime.Now.AddDays(-1)
            });

            SonEklenenFirmalar.Add(new Firma
            {
                Id = 2,
                FirmaAdi = "XYZ İnşaat Ltd.",
                Telefon = "0216 987 65 43",
                VergiNumarasi = "9876543210",
                Yetkili = "Fatma Demir",
                Adres = "Kadıköy/İstanbul",
                EklenmeTarihi = System.DateTime.Now.AddDays(-2)
            });
        }
    }
}