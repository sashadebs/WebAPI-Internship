using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;
using WebApp.Models;

namespace EFApplication.Repository
{
    public class PersonRepo : IPersonRepo //class that implements the interface
    {
        // dependency injection where db context class is injected to
        // controller through instructor
        // immutable dbcontext instance injected
        // use local field to access db context class members
        private readonly AppDbContext dbcontext; 

        public PersonRepo(AppDbContext db)
        {
            dbcontext = db;
        }
        Person IPersonRepo.AddPerson(Person p)
        {
            dbcontext.Person.Add(p);
            dbcontext.SaveChanges();
            return p;
        }

        void IPersonRepo.DeletePerson(Person p)
        {   
                dbcontext.Person.Remove(p);
                dbcontext.SaveChanges();
        }

        IEnumerable<Person> IPersonRepo.GetPeople()
        {
            return dbcontext.Person.ToList();
        }


        Person IPersonRepo.GetPerson(int pID)
        {
            return dbcontext.Person.Include(p => p.Addresses).FirstOrDefault(p => p.ID == pID);
        }

        void IPersonRepo.UpdatePerson()
        {
            dbcontext.SaveChanges();
            return;
        }
    }
}
