using System;
using System.Collections.Generic;

#nullable disable

namespace RegRepresNew
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Title { get; set; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
