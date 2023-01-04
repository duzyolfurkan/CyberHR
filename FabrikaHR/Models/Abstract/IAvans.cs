using FabrikaHR.Models.Enums;
using System;

namespace FabrikaHR.Models.Abstract
{
    public interface IAvans
    {
        int AvansID { get; set; }
        string TalepTuru { get; set; }
        DateTime TalepTarihi { get; set; }
        ParaBirimi ParaBirimi { get; set; }
        double TalepTutari { get; set; }
        string OnayDurumu { get; set; }
        DateTime CevaplanmaTarihi { get; set; }
        string Aciklama { get; set; }

    }
}
