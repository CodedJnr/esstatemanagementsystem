using System;
using Esstate_Management_System.Implementation;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
using Esstate_Management_System.Menu;
namespace Esstate_Management_System.Menu
{
    public class AdminMenu
    {
        IAdminManager adminManager = new AdminManager();
        IPropertiesManager propertiesManager = new PropertiesManager();

        IContractorManager contractorManager = new ContractorManager();


        public void AdminMainMenu()
        {
            Console.WriteLine("Enter 1 to register\nEnter 2 to login\nEnter 3 to back");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                RegisterAdminMenu();
            }
            else if (choice == 2)
            {
                LoginMenu();
            }
            else if (choice == 3)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.MainMenus();
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
        public void RegisterAdminMenu()
        {
            Console.WriteLine("Welcome to Support Manager");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your pin: ");
            string pin = Console.ReadLine();



            Console.Write("Enter your position: ");
            string position = Console.ReadLine();

            adminManager.CreateAdmin(name, email, phoneNumber, pin, position);
            AdminMainMenu();
        }
        public void LoginMenu()
        {
            Console.Write("Enter your admin Id: ");
            string adminId = Console.ReadLine();

            Console.Write("Enter your pin: ");
            string pin = Console.ReadLine();

            Admin admin = adminManager.Login(adminId, pin);
            if (admin != null)
            {
                Console.WriteLine("login successful");
                SupportMenu();
            }
            else
            {
                Console.WriteLine("wrong email or pin,Try Again");
                AdminMainMenu();
            }
        }
        public void SupportMenu()
        {
            Console.WriteLine("Enter 1 to Update Profile\nEnter 2 to Delete profile\nEnter 3 to register Land or Property\nEnter 4 to update Land or Property\nEnter 5 to get a particular Admin\nEnter 6 to get all Admins\nEnter 7 to get a contractor\nEnter 8 to get all contractors\nEnter 9 to back");
            int choice2 = int.Parse(Console.ReadLine());
            if (choice2 == 1)
            {
                UpdateProfile();
            }
            else if (choice2 == 2)
            {
                DeleteProfile();
            }
            else if (choice2 == 3)
            {
                CreateLand();
            }
            else if (choice2 == 4)
            {
                UpdateLand();
            }
            else if (choice2 == 5)
            {
                Get1Admin();
            }
            else if (choice2 == 6)
            {
                GetAllAdmins();
            }
            else if (choice2 == 7)
            {
                Get1Contractor();
            }
            else if (choice2 == 8)
            {
                contractorManager.GetAllContractor();

                Console.Write("Enter any digit to back: ");
                int digit = int.Parse(Console.ReadLine());
                if (digit == 0 || digit == 1 || digit == 2 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9)
                {
                    SupportMenu();
                }
            }
            else if (choice2 == 9)
            {
                AdminMainMenu();
            }
        }
        public void UpdateProfile()
        {
            Console.Write("Enter your new name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your new phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your admin Id: ");
            string adminId = Console.ReadLine();

            adminManager.UpdateAdmin(name, adminId, phoneNumber);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if (digit == 0 || digit == 1 || digit == 2 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9)
            {
                SupportMenu();
            }
        }
        public void DeleteProfile()
        {
            Console.Write("Enter your admin Id: ");
            string adminId = Console.ReadLine();

            adminManager.DeleteAdmin(adminId);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if (digit == 0 || digit == 1 || digit == 2 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9)
            {
                SupportMenu();
            }
        }
        public void CreateLand()
        {
            Console.Write("Enter your property name: ");
            string propertyName = Console.ReadLine();

            Console.Write("Enter your property price: $");
            double price = double.Parse(Console.ReadLine());

            propertiesManager.CreateProperties(propertyName, price);
            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if (digit == 0 || digit == 1 || digit == 2 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9)
            {
                SupportMenu();
            }
        }
        public void UpdateLand()
        {
            Console.Write("Enter property name: ");
            string propertyName = Console.ReadLine();

            Console.Write("Enter your new property name: ");
            string newPropertyName = Console.ReadLine();

            Console.Write("Enter your new price: ");
            double newPrice = double.Parse(Console.ReadLine());

            propertiesManager.UpdateProperties(propertyName, newPropertyName, newPrice);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if (digit == 0 || digit == 1 || digit == 2 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9)
            {
                SupportMenu();
            }
        }
        public void Get1Admin()
        {
            Console.Write("Enter Admin Id of the admin personnel");
            string adminId = Console.ReadLine();
            adminManager.GetAdmin(adminId);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if (digit == 0 || digit == 1 || digit == 2 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9)
            {
                SupportMenu();
            }
        }
        public void GetAllAdmins()
        {
            var list = adminManager.GetAllAdmin();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Email}\t{item.PhoneNumber}\t{item.Pin}\t{item.Post}\t{item.AdminID}");
            }
            // Console.Write("Enter any digit to back");
            // int digit = int.Parse(Console.ReadLine());
            // if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            // {
            SupportMenu();
            // }
        }
        public void Get1Contractor()
        {
            Console.Write("Enter Contractor id: ");
            string contractorId = Console.ReadLine();
            contractorManager.GetContractor(contractorId);

            // Console.Write("Enter any digit to back");
            // int digit = int.Parse(Console.ReadLine());
            // if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            // {
            SupportMenu();
            // }
        }
    }
}