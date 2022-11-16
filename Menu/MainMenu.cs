using System;
using Esstate_Management_System.Implementation;

namespace Esstate_Management_System.Menu
{
    public class MainMenu
    {
        public void MainMenus()
        {
            Console.WriteLine("Welcome to Esstate  Management System \nHow can we help you?");

            Console.WriteLine("Enter 1 as Admin\nEnter 2 as Contractor\nEnter 3 as Buyer");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                Console.Write("Please Enter Admin PassWord to access feature: ");
                string passWord = Console.ReadLine();
                if (passWord == "Ad@Esstate5683")
                {
                    Console.WriteLine("Access Granted!");
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.AdminMainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid Password! Please try again later");
                }
            }
            else if (opt == 2)
            {
                ContractorMenu contractorMenu = new ContractorMenu();
                contractorMenu.ContractorMainMenu();
            }
            else if (opt == 3)
            {
                CustomerMenu customerMenu = new CustomerMenu();
                customerMenu.CustomerMainMenu();
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
    }
}