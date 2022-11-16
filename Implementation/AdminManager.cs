using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Implementation
{
    public class AdminManager : IAdminManager
    {
        public static List<Admin> listOfAdmin = new List<Admin>();
        public string adminFilePath = @"./Files/admin.txt";
        public string fileDirect = @"./Files";

        public void CreateAdmin(string name, string email, string phoneNumber, string pin, string post)
        {
            Random rand = new Random();
            int id = listOfAdmin.Count + 1;
            string adminId = "CEM/MS" + rand.Next(100, 999).ToString();
            Admin adm = new Admin(id, name, email, phoneNumber, pin, post, adminId);
            listOfAdmin.Add(adm);
            using (var streamWriter = new StreamWriter(adminFilePath, append: true))
            {
                streamWriter.WriteLine(adm.WriteToFIle());
            }
            Console.WriteLine($"Thank you Mr. {adm.Name}, your staff identity number is {adm.AdminID}");
        }

        public void DeleteAdmin(string adminId)
        {
            Admin adm = GetAdmin(adminId);
            if(adm != null)
            {
                listOfAdmin.Remove(adm);

            }
            else
            {
                Console.WriteLine("Manager or support personnel not found");
            }
        }

        public Admin GetAdmin(string adminId)
        {
            foreach (var item in listOfAdmin)
            {
                if(item.AdminID == adminId)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Admin> GetAllAdmin()
        {
            return listOfAdmin;
        }

        public Admin Login(string adminId, string pin)
        {
            foreach (var item in listOfAdmin)
            {
                if (item.AdminID == adminId && item.Pin == pin)
                {
                   return item;
                }
            }
            return null;
        }

        public void ReadFromFile()
        {
            if (!Directory.Exists(fileDirect)) 
            Directory.CreateDirectory(fileDirect);

            if (!File.Exists(adminFilePath))
            {
                var fileStream = new FileStream(adminFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(adminFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var adminManager = streamReader.ReadLine();
                    listOfAdmin.Add(Admin.ConvertToAdmin(adminManager));
                }
            }
        }

        public void ReWriteToFile()
        {
            File.WriteAllText(adminFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(adminFilePath, append: true))
            {
                foreach (var item in listOfAdmin)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }

        public void UpdateAdmin(string adminId, string name, string phoneNumber)
        {
            Admin ad =  GetAdmin(adminId);
            if(ad == null)
            {
                Console.WriteLine("Admin personnel not found");
            }
            else
            {
                ad.Name = name;
                ad.PhoneNumber = phoneNumber;
            }
        }
    }
}