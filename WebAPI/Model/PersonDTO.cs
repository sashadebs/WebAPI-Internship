namespace WebAPI.Model
{
    public class PersonDTO
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //no need in dto
        //public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public string Email { get; set; }

    }
}
