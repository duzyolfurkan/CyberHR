using FabrikaHR.Models.Abstract;
using FabrikaHR.Models.Enums;
using System;

namespace FabrikaHR.Models.Concrate
{
    public class Harcama : IHarcama
    {
        public int HarcamaID { get; set; }
        public string HarcamaTuru { get; set; }
        public DateTime TalepTarihi { get; set; }
        public ParaBirimi ParaBirimi { get; set; }
        public double HarcamaTutari { get; set; }
        public string OnayDurumu { get; set; }
        public DateTime CevaplanmaTarihi { get; set; }
        public byte[] EkDosya { get; set; }

        //User tablosu ile bağlantı
        public User User { get; set; }
        public int UserID { get; set; }

    }
}
