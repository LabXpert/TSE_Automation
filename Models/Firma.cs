using System;

namespace TSE_Automation.Models
{
    public class Firma
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string? VergiNumarasi { get; set; }
        public string Yetkili { get; set; } = string.Empty;
        public string? Adres { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
    }
}