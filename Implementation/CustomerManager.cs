using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        public static List<Customer> listOfCustomer = new List<Customer>();
        public string customerFilePath = @"./Files/customer.txt";
        public string fileDirect = @"./Files";
        public void CreateCustomer(string name, string email, string phoneNumber, string pin, string address)
        {
            Random rand = new Random();
            int id = listOfCustomer.Count + 1;
            string customerId = "CEM/MS" + rand.Next(100, 999).ToString();
            Customer adm = new Customer(id, name, email, phoneNumber, pin , address, customerId);
            listOfCustomer.Add(adm);
            using (var streamWriter = new StreamWriter(customerFilePath, append: true))
            {
                streamWriter.WriteLine(adm.WriteToFIle());
            }
            Console.WriteLine($"Thank you Mr. {adm.Name} your id is {adm.CustomerID}");
        }

        public void DeleteCustomer(string customerId)
        {
            Customer adm = GetCustomer(customerId);
            if(adm != null)
            {
                listOfCustomer.Remove(adm);

            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        public Customer GetCustomer(string customerId)
        {
            foreach (var item in listOfCustomer)
            {
                if(item.CustomerID == customerId)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Customer> GetAllCustomer()
        {
            return listOfCustomer;
        }

        public Customer Login(string customerId,string pin)
        {
            foreach (var item in listOfCustomer)
            {
                if (item.CustomerID == customerId && item.Pin == pin)
                {
                   return item;
                }
            }
            return null;
        }

        public void UpdateCustomer(string customerId, string name, string phoneNumber)
        {
            Customer ad =  GetCustomer(customerId);
            if(ad == null)
            {
                Console.WriteLine("customer not found");
            }
            else
            {
                ad.Name = name;
                ad.PhoneNumber = phoneNumber;
            }
        }

        public void ReadFromFile()
        {
            if (!Directory.Exists(fileDirect)) 
            Directory.CreateDirectory(fileDirect);

            if (!File.Exists(customerFilePath))
            {
                var fileStream = new FileStream(customerFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(customerFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var customerManager = streamReader.ReadLine();
                    listOfCustomer.Add(Customer.ConvertToCustomer(customerManager));
                }
            }
        }

        public void ReWriteToFile()
        {
            File.WriteAllText(customerFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(customerFilePath, append: true))
            {
                foreach (var item in listOfCustomer)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
    }
}