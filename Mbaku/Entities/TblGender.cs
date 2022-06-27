using System;
using System.Collections.Generic;

#nullable disable

namespace Mbaku.Entities
{
    public partial class TblGender
    {
        public TblGender()
        {
            TblPeople = new HashSet<TblPerson>();
        }

        public int Id { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<TblPerson> TblPeople { get; set; }
    }
}
