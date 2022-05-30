using System;
using System.Collections.Generic;

#nullable disable

namespace RegRepresNew
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Discription { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
