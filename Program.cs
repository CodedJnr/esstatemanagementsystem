using System;
using Esstate_Management_System.Implementation;
using Esstate_Management_System.Menu;

namespace Esstate_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminManager ad = new AdminManager();
            ad.ReadFromFile();
            var cashierManager = new CashierManager();
            cashierManager.ReWriteToFile();
            var contractor = new ContractorManager();
            contractor.ReadFromFile();
            var customer = new CustomerManager();
            customer.ReadFromFile();
            var properties = new PropertiesManager();
            properties.ReadFromFile();

            MainMenu mainMenu = new MainMenu();
            mainMenu.MainMenus();


        }
    }
}