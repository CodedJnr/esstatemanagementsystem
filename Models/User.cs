using System;
namespace Esstate_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pin { get; set; }

        public User(int id, string name,string email, string phoneNumber, string pin)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Pin = pin;
        }
    }
}