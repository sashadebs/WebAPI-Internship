using EFApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Model;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //  This attribute indicates that the controller responds to web API requests.
    public class PersonController : ControllerBase
    {

        private readonly IPersonRepo _personRepo;
        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet("token")]
        public string GetToken()
        {
            return "tokenvalue";
        } 


        [HttpGet] // attribute that denotes a method responds to an HTTP GET request
        public ActionResult<IEnumerable<PersonDTO>> GetPeople()
        {
            var people = from p in _personRepo.GetPeople()
                         select new PersonDTO()
                         {
                             ID = p.ID,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             //Addresses = p.Addresses,
                             Email = p.Email
                         };
            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDTO> GetPerson(int id)
        // ActionResult return types can represent a wide range of HTTP status codes
        {
            var p = _personRepo.GetPerson(id);

            if (p is null)
                return NotFound();

            var pDto = new PersonDTO
            {
                ID = p.ID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email
            };

            return Ok(pDto);
        }

        [HttpPost("new")]
        public ActionResult<PersonDTO> AddPerson(PersonDTO pDto)
        {
            var toAddP = new Person()
            {
                FirstName = pDto.FirstName,
                LastName = pDto.LastName,
                Email = pDto.Email,
            };

            var addedP = _personRepo.AddPerson(toAddP);

            return CreatedAtAction(nameof(GetPerson), new { id = addedP.ID }, addedP);
        }

        [HttpPut("{id}")]
        public ActionResult<Person> UpdatePerson(int id, PersonDTO pDto)
        {
            Person toChange = _personRepo.GetPerson(id);
            if (toChange != null)
            {
                toChange.FirstName = pDto.FirstName;
                toChange.LastName = pDto.LastName;
                toChange.Email = pDto.Email;

                _personRepo.UpdatePerson();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> DeletePerson(int id)
        {
            Person result = _personRepo.GetPerson(id);
            if (result != null)
            {
                _personRepo.DeletePerson(result);
                return NoContent();
            }
            return NotFound();
        }


        // -------------------------------------------- ADDRESS -----------------------------------------------

        [HttpPost("{id}/address")]
        public ActionResult AddAddress(AddressDTO aDto, int id)
        {
            Person? person = _personRepo.GetPerson(id);

            if (person is null) return NotFound();

            var address = new Address()
            {
                Country = aDto.Country,
                City = aDto.City,
                Phone = aDto.Phone,
                Street = aDto.Street
            };

            person.AddAddress(address);
            _personRepo.UpdatePerson();

            return Ok();
        }

        [HttpDelete("{id}/address/{aID}")]
        public ActionResult<Address> DeleteAddress(int aID, int id)
        {
            var person = _personRepo.GetPerson(id);
            Address toDelete = person.Addresses.FirstOrDefault(a => a.ID == aID);
            if (toDelete != null)
            {
                person.Addresses.Remove(toDelete);
                _personRepo.UpdatePerson();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}/address/{aID}")]
        public ActionResult<Address> UpdateAddress(AddressDTO aDto, int id, int aID)
        {
            var person = _personRepo.GetPerson(id);
            Address toUpdate = person.Addresses.FirstOrDefault(a => a.ID == aID);
            if (toUpdate != null)
            {
                toUpdate.Country = aDto.Country;
                toUpdate.City = aDto.City;
                toUpdate.Phone = aDto.Phone;
                toUpdate.Street = aDto.Street;
                _personRepo.UpdatePerson();
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}/Addresses")]
        public ActionResult<IEnumerable<AddressDTO>> GetAddresses(int id)  
        {
            Person? person = _personRepo.GetPerson(id);
            if (person is null) return NotFound();

            var addresses = person.Addresses;
            
                IEnumerable<AddressDTO> addressesDto = from a in addresses
                                                       select new AddressDTO()
                                                       {    
                                                           ID = a.ID,
                                                           Country = a.Country,
                                                           City = a.City,
                                                           Phone = a.Phone,
                                                           Street = a.Street
                                                       };
                return Ok(addressesDto);
            
            //return NotFound();
        }


    }
}
