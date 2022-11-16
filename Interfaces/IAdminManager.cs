using System.Collections.Generic;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Interfaces
{
    public interface IAdminManager
    {
        void CreateAdmin(string name, string email, string phoneNumber, string pin, string post);
        Admin GetAdmin(string adminId);
        List<Admin> GetAllAdmin();
        void UpdateAdmin(string adminId,string name, string phoneNumber);
        void DeleteAdmin(string adminId);
        Admin Login(string adminId, string pin);
        void ReadFromFile ();
        void ReWriteToFile();
    }
}