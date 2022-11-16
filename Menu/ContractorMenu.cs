using System;
using Esstate_Management_System.Implementation;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Menu
{
    public class ContractorMenu
    {
        IContractorManager contractorManager = new ContractorManager();
        
        public void ContractorMainMenu()
        {
            Console.WriteLine("Enter 1 to register\nEnter 2 to login\nEnter 3 to back");
            int choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                RegisterContractorMenu();
            }
            else if(choice == 2)
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
        public void RegisterContractorMenu()
        {
            Console.WriteLine("Welcome to contractor menu");

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

            contractorManager.CreateContractor(name, email, pin, phoneNumber);
            ContractorMainMenu();
        }
        public void LoginMenu()
        {
            Console.Write("Enter your Contractor Id: ");
            string contractorId = Console.ReadLine();

            Console.Write("Enter your pin: ");
            string pin = Console.ReadLine();

            Contractor contractor = contractorManager.Login(contractorId, pin);
            if(contractor != null)
            {
                Console.WriteLine("login successful");
                SupportMenu();
            }
            else
            {
                Console.WriteLine("wrong email or pin,Try Again");
                ContractorMainMenu();
            }
        }
        public void SupportMenu()
        {
            Console.WriteLine("Enter 1 to Update Profile\nEnter 2 to Delete profile\nEnter 3 to get contractor\nEnter 4 to go back");
            int choice2 = int.Parse(Console.ReadLine());
            if(choice2 == 1)
            {
                UpdateProfile();
            }
            else if(choice2 == 2)
            {
                DeleteProfile();
            }
            else if(choice2 == 3)
            {
                Get1Contractor();
            }
            else if(choice2 == 4)
            {
                ContractorMainMenu();
            }   
        }
        public void UpdateProfile()
        {
            Console.Write("Enter your new name: ");
            string  name = Console.ReadLine();

            Console.Write("Enter your new phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your contractor Id: ");
            string contractorId = Console.ReadLine();

            contractorManager.UpdateContractor(name, contractorId,  phoneNumber); 

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            }
        }
        public void DeleteProfile()
        {
            Console.Write("Enter your contractor Id: ");
            string contractorId = Console.ReadLine();

            contractorManager.DeleteContractor(contractorId);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            } 
        }
        public void Get1Contractor()
        {
            Console.Write("Enter your contractor Id: ");
            string contractorId = Console.ReadLine();

            contractorManager.GetContractor(contractorId);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            }
        }
    }
}