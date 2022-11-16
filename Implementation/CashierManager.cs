using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Implementation
{
    public class CashierManager : ICashier
    {
        public static List<Cashier> listOfCashier = new List<Cashier>();
        public string cashierFilePath = @"./Files/cashier.txt";
        public string fileDirect = @"./Files";

        public void DeletePurchase(int id)
        {
            Cashier adm = GetPurchase(id);
            if(adm != null)
            {
                listOfCashier.Remove(adm);

            }
            else
            {
                Console.WriteLine("Purchase not found");
            }
        }

        public Cashier GetPurchase(int id)
        {
            foreach (var item in listOfCashier)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Cashier> GetAllPurchases()
        {
            return listOfCashier;
        }

        public void MakePurchase(string Email, string choiceAddress, string paymentStatus, double totalPrice)
        {
            int id = listOfCashier.Count + 1;
            Cashier adm = new Cashier(id, Email, choiceAddress, paymentStatus, totalPrice);
            listOfCashier.Add(adm);
            using (var streamWriter = new StreamWriter(cashierFilePath, append: true))
            {
                streamWriter.WriteLine(adm.WriteToFIle());
            }
            Console.WriteLine($"Thank you, your purchase id is {adm.Id}");
        }

        public void ReadFromFile()
        {
            if (!Directory.Exists(fileDirect)) 
            Directory.CreateDirectory(fileDirect);

            if (!File.Exists(cashierFilePath))
            {
                var fileStream = new FileStream(cashierFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(cashierFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var cashierManager = streamReader.ReadLine();
                    listOfCashier.Add(Cashier.ConvertToCashier(cashierManager));
                }
            }
        }

        public void ReWriteToFile()
        {
            File.WriteAllText(cashierFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(cashierFilePath, append: true))
            {
                foreach (var item in listOfCashier)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }

        public void StatusToReady(int id)
        {
            foreach (var item in listOfCashier)
            {
                if(item.PaymentStatus == "ordered")
                {
                    item.PaymentStatus = "Ready";
                }
            }
        }
    }
}