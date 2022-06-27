using System;
using System.Collections.Generic;

#nullable disable

namespace Mbaku.Entities
{
    public partial class TblPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? GenderId { get; set; }

        public virtual TblGender Gender { get; set; }
    }
}
