namespace Esstate_Management_System.Models
{
    public class Cashier
    {
        public int Id{ get; set; }
        public string Email {get; set;}
        public string ChoiceAddress {get; set;}
        public string PaymentStatus {get; set;}
        public double TotalPrice {get; set;}

        public Cashier (int id, string email, string choiceAddress, string paymentStatus, double totalPrice)
        {
            Id = id;
            Email = email;
            ChoiceAddress = choiceAddress;
            PaymentStatus = paymentStatus;
            TotalPrice = totalPrice;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{Email}%%%%%{ChoiceAddress}%%%%%{PaymentStatus}%%%%%{TotalPrice}";
        }

        public static Cashier ConvertToCashier(string cashierAllFromText)
        {
            var cashierConvert = cashierAllFromText.Split("%%%%%");
            return new Cashier(int.Parse(cashierConvert[0]), cashierConvert[1], cashierConvert[2], cashierConvert[3], double.Parse(cashierConvert[4]));
        }
    }
}