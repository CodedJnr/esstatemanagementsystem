namespace Esstate_Management_System.Models
{
    public class Admin : User
    {
        public string Post { get; set; }
        public string AdminID { get; set; }
        
        public Admin(int id,string name,string email, string phoneNumber, string pin, string post, string adminId) : base(id, name, email, phoneNumber, pin)
        {
            Post = post;
            AdminID = adminId;
        }
        public string WriteToFIle()
        {
            return $"{Id}%%%%%{Name}%%%%%{Email}%%%%%{PhoneNumber}%%%%%{Pin}%%%%%{Post}%%%%%{AdminID}";
        }

        public static Admin ConvertToAdmin(string adminAllFromText)
        {
            var adminConvert = adminAllFromText.Split("%%%%%");
            return new Admin(int.Parse(adminConvert[0]), adminConvert[1], adminConvert[2], adminConvert[3], adminConvert[4], adminConvert[5], adminConvert[6]);
        }
    }
}