namespace WebAPI.Model
{
    public class Person
    {   // attributes in Person table
        public int ID { get; set; } //primary key

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // one to many relationship
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public string Email { get; set; }

        public void AddAddress(Address address)
        {
            if (Addresses.Contains(address))
            {
                throw new Exception("Address already exists");
            }
            this.Addresses.Add(address);
            return;
        }



    }
}
