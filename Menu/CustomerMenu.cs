using System;
using Esstate_Management_System.Implementation;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Menu
{
    public class CustomerMenu
    {
        ICustomerManager customerManager = new CustomerManager();
        ICashier cashierManager = new CashierManager();
        IContractorManager contractorManager = new ContractorManager();
        IPropertiesManager propertiesManager = new PropertiesManager();
        
        public void CustomerMainMenu()
        {
            Console.WriteLine("Enter 1 to register\nEnter 2 to login\nEnter 3 to back");
            int choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                RegisterCustomerMenu();
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
        public void RegisterCustomerMenu()
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

            Console.Write("Enter your address: ");
            string address = Console.ReadLine();

            customerManager.CreateCustomer(name,email,phoneNumber,pin,address);
            CustomerMainMenu();
        }
        public void LoginMenu()
        {
            Console.Write("Enter your customer Id: ");
            string customerId = Console.ReadLine();

            Console.Write("Enter your pin: ");
            string pin = Console.ReadLine();

            Customer customer = customerManager.Login(customerId, pin);
            if(customer != null)
            {
                Console.WriteLine("login successful");
                SupportMenu();
            }
            else
            {
                Console.WriteLine("wrong email or pin,Try Again");
                CustomerMainMenu();
            }
        }
        public void SupportMenu()
        {
            Console.WriteLine("Enter 1 to Update Profile\nEnter 2 to Delete profile\nEnter 3 to view all available properties\nEnter 4 to purchase Land or Property\nEnter 5 to get purchase\nEnter 6 to get all purchases\nEnter 7 to delete purchase\nEnter 8 to get contractors\nEnter 9 to back");
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
                propertiesManager.GetAllProperties();
                SupportMenu();
            }
            else if(choice2 == 4)
            {
                PurchaseLand();
            }
            else if(choice2 == 5)
            {
                CheckPurchase();
            }
            else if(choice2 == 6)
            {
                cashierManager.GetAllPurchases();

                Console.Write("Enter any digit to back: ");
                int digit = int.Parse(Console.ReadLine());
                if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
                {
                    SupportMenu();
                }
            }
            else if(choice2 == 7)
            {
                RemovePurchase();
            } 
            else if(choice2 == 8)
            {
                GetContractors();
            }  
            else if(choice2 == 9)
            {
                CustomerMainMenu();
            }   
        }
        public void UpdateProfile()
        {
            Console.Write("Enter your new name: ");
            string  name = Console.ReadLine();

            Console.Write("Enter your new phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your customer Id: ");
            string customerId = Console.ReadLine();

            customerManager.UpdateCustomer(name, customerId,  phoneNumber); 

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            }
        }
        public void DeleteProfile()
        {
            Console.Write("Enter your customer Id: ");
            string customerId = Console.ReadLine();

            customerManager.DeleteCustomer(customerId); 

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            }
        }
        public void PurchaseLand()
        {
            Console.Write("Enter your Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your choice address: ");
            string choiceAddress = Console.ReadLine();

            Console.Write("Enter your payment status: ");
            string paymentStatus = Console.ReadLine();

            Console.Write("Enter your budget price: ");
            double totalPrice = double.Parse(Console.ReadLine());

            cashierManager.MakePurchase(email, choiceAddress, paymentStatus, totalPrice); 

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            }
        }
        public void CheckPurchase()
        {
            Console.Write("Enter your id: ");
            int id = int.Parse(Console.ReadLine());

            cashierManager.GetPurchase(id);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            }
        }
        public void RemovePurchase()
        {
            Console.Write("Enter your id: ");
            int id = int.Parse(Console.ReadLine());

            cashierManager.DeletePurchase(id);

            Console.Write("Enter any digit to back: ");
            int digit = int.Parse(Console.ReadLine());
            if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
            {
                SupportMenu();
            }
        }

        public void GetContractors()
        {
            Console.Write("Why do you need the contractor's service?\n1. Build on purchased land\n2. Modify property");
            int need = int.Parse(Console.ReadLine());
            if(need == 1 || need == 2)
            {
                Console.WriteLine("Below are the list of recomended contractors");
                contractorManager.GetAllContractor();

                Console.Write("Enter any digit to back: ");
                int digit = int.Parse(Console.ReadLine());
                if(digit == 0 ||digit == 1 ||digit == 2 ||digit == 3 ||digit == 4 ||digit == 5 ||digit == 6 ||digit == 7 ||digit == 8 ||digit == 9)
                {
                    SupportMenu();
                }
            }
        }
    }
}