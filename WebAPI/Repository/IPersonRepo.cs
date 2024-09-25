using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;

namespace EFApplication.Repository
{
    public interface IPersonRepo
    {
        Person GetPerson(int pID);
        IEnumerable<Person> GetPeople();
        Person AddPerson(Person p);
        void DeletePerson(Person p);
        void UpdatePerson();
    }
}
