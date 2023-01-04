using FabrikaHR.Models.Enums;
using System;

namespace FabrikaHR.Models.Abstract
{
    public interface IHarcama
    {
        int HarcamaID { get; set; }
        string HarcamaTuru { get; set; }
        DateTime TalepTarihi { get; set; }
        ParaBirimi ParaBirimi { get; set; }
        double HarcamaTutari { get; set; }
        string OnayDurumu { get; set; }
        DateTime CevaplanmaTarihi { get; set; }
        byte[] EkDosya { get; set; }

    }
}
