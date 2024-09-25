namespace WebAPI.Model
{
    public class AddressDTO
    {
        public int ID { get; set; } //primary  key
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
    }
}
