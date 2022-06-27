using System;
using System.Collections.Generic;

#nullable disable

namespace Mbaku.Entities
{
    public partial class EmpManager
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
    }
}
