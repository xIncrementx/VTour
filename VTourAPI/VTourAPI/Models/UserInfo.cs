namespace VTourAPI.Models
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}