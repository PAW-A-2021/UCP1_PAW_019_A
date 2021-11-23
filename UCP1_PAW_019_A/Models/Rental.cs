using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_019_A.Models
{
    public partial class Rental
    {
        public Rental()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdRental { get; set; }
        public DateTime? TglPeminjaman { get; set; }
        public int? HargaSewa { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
