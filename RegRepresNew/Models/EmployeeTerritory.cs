using System;
using System.Collections.Generic;

#nullable disable

namespace RegRepresNew
{
    public partial class EmployeeTerritory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
