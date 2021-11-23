using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_019_A.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdPenyewa { get; set; }
        public int? IdRental { get; set; }
        public int? IdPlayStation { get; set; }
        public int? HargaSewa { get; set; }

        public virtual Penyewa IdPenyewaNavigation { get; set; }
        public virtual PlayStation IdPlayStationNavigation { get; set; }
        public virtual Rental IdRentalNavigation { get; set; }
    }
}
