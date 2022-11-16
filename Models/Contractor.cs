namespace Esstate_Management_System.Models
{
    public class Contractor : User
    {
        public string ContractorID { get; set; }
        public Contractor(int id,string name,string email, string phoneNumber, string pin, string contractorId) : base(id, name, email, phoneNumber, pin)
        {
            ContractorID = contractorId;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{Name}%%%%%{Email}%%%%%{PhoneNumber}%%%%%{Pin}%%%%%{ContractorID}";
        }

        public static Contractor ConvertToContractor(string contractorAllFromText)
        {
            var contractorConvert = contractorAllFromText.Split("%%%%%");
            return new Contractor(int.Parse(contractorConvert[0]), contractorConvert[1], contractorConvert[2], contractorConvert[3], contractorConvert[4], contractorConvert[5]);
        }
    }
}