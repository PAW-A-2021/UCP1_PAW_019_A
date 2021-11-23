using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_019_A.Models
{
    public partial class PlayStation
    {
        public PlayStation()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdPlayStation { get; set; }
        public string JenisPlayStation { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
