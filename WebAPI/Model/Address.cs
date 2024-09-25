namespace WebAPI.Model
{
    public class Address
    {   
        public int ID { get; set; } //primary  key
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public int PersonID { get; set; } //foreign key

        public Person Person { get; set; } //navigation property to represent person
      
    }
}
