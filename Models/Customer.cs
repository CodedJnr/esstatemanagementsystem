namespace Esstate_Management_System.Models
{
    public class Customer : User
    {
        public string Address { get; set; }
        public string CustomerID { get; set; }
        public Customer(int id,string name,string email, string phoneNumber, string pin, string address, string customerId) : base(id, name, email, phoneNumber, pin)
        {
            Address = address;
            CustomerID = customerId;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{Name}%%%%%{Email}%%%%%{PhoneNumber}%%%%%{Pin}%%%%%{Address}%%%%%{CustomerID}";
        }

        public static Customer ConvertToCustomer(string customerAllFromText)
        {
            var customerConvert = customerAllFromText.Split("%%%%%");
            return new Customer(int.Parse(customerConvert[0]), customerConvert[1], customerConvert[2], customerConvert[3], customerConvert[4], customerConvert[5], customerConvert[6]);
        }
    }
}