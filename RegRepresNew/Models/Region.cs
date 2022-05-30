using System;
using System.Collections.Generic;

#nullable disable

namespace RegRepresNew
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public int Id { get; set; }
        public string Regiondiscription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
