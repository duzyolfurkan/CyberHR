using FabrikaHR.Models.Abstract;
using FabrikaHR.Models.Enums;
using System;

namespace FabrikaHR.Models.Concrate
{
    public class Avans : IAvans
    {
        public int AvansID { get; set; }
        public string TalepTuru { get; set; }
        public DateTime TalepTarihi { get; set; }
        public ParaBirimi ParaBirimi { get; set; }
        public double TalepTutari { get; set; }
        public string OnayDurumu { get; set; }
        public DateTime CevaplanmaTarihi { get; set; }
        public string Aciklama { get; set; }

        //User tablosu ile bağlantı
        public User User { get; set; }
        public int UserID { get; set; }


    }
}
