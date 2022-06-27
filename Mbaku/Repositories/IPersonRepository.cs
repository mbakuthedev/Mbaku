using Mbaku.Entities;
using System.Collections.Generic;

namespace Mbaku.Repositories
{
    public interface IPersonRepository
    {
        TblPerson Create(TblPerson newPerson);
        TblPerson Delete(int Id);
        TblPerson Delete(int? Id);
        TblPerson GetPerson(int Id);
        ICollection<TblPerson> Index(TblPerson person);
        TblPerson Update(int Id);
        TblPerson Update(TblPerson UpdatedPerson);
    }
}