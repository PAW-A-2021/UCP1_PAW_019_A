using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_019_A.Models
{
    public partial class Penyewa
    {
        public Penyewa()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdPenyewa { get; set; }
        public string Nama { get; set; }
        public string NomorTelpon { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
