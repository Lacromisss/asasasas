using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    internal class Stadion
    {
        List<Stadion> Stadions { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }




        public int Capacity { get; set; }
        public decimal HourPrice { get; set; }

    }
}