using Mbaku.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbaku.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        //Dependency Injection
        private readonly PersonContext db = new();
        public PersonRepository(PersonContext personcontext)
        {
            db = personcontext;
        }
        //Index Page
        public ICollection<TblPerson> Index(TblPerson person)
        {
            ICollection<TblPerson> Persons = db.TblPeople.Include(g => g.Gender).ToList();
            return Persons;
        }
        //Create Page
        public TblPerson Create(TblPerson newPerson)
        {
            db.TblPeople.Add(newPerson);
            db.SaveChanges();
            return newPerson;
        }
        //Edit Page
        public TblPerson GetPerson(int Id)
        {
            TblPerson person = db.TblPeople.Include(g => g.Gender).FirstOrDefault(c => c.Id == Id);
            return person;
        }
        //Update Page<<ID>>
        public TblPerson Update(int Id)
        {
            TblPerson Person = db.TblPeople.Find(Id);
            return Person;
        }
        //Update Page
        public TblPerson Update(TblPerson UpdatedPerson)
        {
            db.Entry(UpdatedPerson);
            db.Entry(UpdatedPerson).State = EntityState.Modified;
            db.SaveChanges();
            return UpdatedPerson;
        }
        //Delete <<ID>>
        public TblPerson Delete(int? Id)
        {
            TblPerson Person = db.TblPeople.Find(Id);
            return Person;
        }
        //Delete
        public TblPerson Delete(int Id)
        {
            TblPerson Person = db.TblPeople.Find(Id);
            db.TblPeople.Remove(Person);
            db.SaveChanges();
            return Person;
        }
    }
}
