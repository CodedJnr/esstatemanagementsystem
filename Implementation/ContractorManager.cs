using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Implementation
{
    public class ContractorManager : IContractorManager
    {
        public static List<Contractor> listOfContractor = new List<Contractor>();
        public string contractorFilePath = @"./Files/contractor.txt";
        public string fileDirect = @"./Files";
        public void CreateContractor(string name, string email, string pin, string phoneNumber)
        {
            Random rand = new Random();
            int id = listOfContractor.Count + 1;
            string contractorId = "CEM/MS" + rand.Next(100, 999).ToString();
            Contractor adm = new Contractor(id, name, email, phoneNumber, pin, contractorId);
            listOfContractor.Add(adm);
            using (var streamWriter = new StreamWriter(contractorFilePath, append: true))
            {
                streamWriter.WriteLine(adm.WriteToFIle());
            }
            Console.WriteLine($"Thank you Mr. {adm.Name}, your contractor id is {adm.ContractorID}");
        }

        public void DeleteContractor(string contractorId)
        {
            Contractor adm = GetContractor(contractorId);
            if(adm != null)
            {
                listOfContractor.Remove(adm);

            }
            else
            {
                Console.WriteLine("Contractor not found");
            }
        }

        public List<Contractor> GetAllContractor()
        {
            return listOfContractor;
        }

        public Contractor GetContractor(string contractorId)
        {
            foreach (var item in listOfContractor)
            {
                if(item.ContractorID == contractorId)
                {
                    return item;
                }
            }
            return null;
        }

        public Contractor Login(string contractorId, string pin)
        {
            foreach (var item in listOfContractor)
            {
                if (item.ContractorID == contractorId && item.Pin == pin)
                {
                   return item;
                }
            }
            return null;
        }

        public void UpdateContractor(string name, string phoneNumber, string contractorId)
        {
            Contractor ad =  GetContractor(contractorId);
            if(ad == null)
            {
                Console.WriteLine("Contractor not found");
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

            if (!File.Exists(contractorFilePath))
            {
                var fileStream = new FileStream(contractorFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(contractorFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var contractorManager = streamReader.ReadLine();
                    listOfContractor.Add(Contractor.ConvertToContractor(contractorManager));
                }
            }
        }

        public void ReWriteToFile()
        {
            File.WriteAllText(contractorFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(contractorFilePath, append: true))
            {
                foreach (var item in listOfContractor)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
    }
}