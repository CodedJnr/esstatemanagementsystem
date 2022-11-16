using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Esstate_Management_System.Interfaces;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Implementation
{
    public class PropertiesManager : IPropertiesManager
    {
        public static List<Properties> listOfProperties = new List<Properties>();
        public string propertiesFilePath = @"./Files/properties.txt";
        public string fileDirect = @"./Files";
        public void CreateProperties(string propertyName, double price)
        {
            int id = listOfProperties.Count + 1;
            Properties adm = new Properties(id, propertyName, price);
            listOfProperties.Add(adm);
            using (var streamWriter = new StreamWriter(propertiesFilePath, append: true))
            {
                streamWriter.WriteLine(adm.WriteToFIle());
            }
            Console.WriteLine($"Property {adm.PropertyName} succesfully created");
        }

        public void DeleteProperties(string propertyName)
        {
            Properties adm = GetProperties(propertyName);
            if(adm != null)
            {
                listOfProperties.Remove(adm);

            }
            else
            {
                Console.WriteLine("Property not found");
            }
        }

        public List<Properties> GetAllProperties()
        {
            return listOfProperties;
        }

        public Properties GetProperties(string propertyName)
        {
            foreach (var item in listOfProperties)
            {
                if(item.PropertyName == propertyName)
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateProperties(string propertyName, string newPropertyName, double newPropertyPrice)
        {
            Properties ad =  GetProperties(propertyName);
            if(ad == null)
            {
                Console.WriteLine("Property not found");
            }
            else
            {
                ad.PropertyName = newPropertyName;
                ad.Price = newPropertyPrice;
            }
        }

        public void ReadFromFile()
        {
            if (!Directory.Exists(fileDirect)) 
            Directory.CreateDirectory(fileDirect);

            if (!File.Exists(propertiesFilePath))
            {
                var fileStream = new FileStream(propertiesFilePath, FileMode.CreateNew);
                fileStream.Close();
            }
            using (var streamReader = new StreamReader(propertiesFilePath))
            {
                while (streamReader.Peek() != -1)
                {
                    var adminManager = streamReader.ReadLine();
                    listOfProperties.Add(Properties.ConvertToProperties(adminManager));
                }
            }
        }

        public void ReWriteToFile()
        {
            File.WriteAllText(propertiesFilePath, string.Empty);
            using (var streamWriter = new StreamWriter(propertiesFilePath, append: true))
            {
                foreach (var item in listOfProperties)
                {
                    streamWriter.WriteLine(item.WriteToFIle());
                }
            }
        }
    }
}