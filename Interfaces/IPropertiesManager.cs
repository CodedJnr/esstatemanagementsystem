using System.Collections.Generic;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Interfaces
{
    public interface IPropertiesManager
    {
        public void CreateProperties (string propertyName, double price);
        public void UpdateProperties (string propertyName,string newPropertyName, double newPropertyPrice );
        public void DeleteProperties (string propertyName);
        public Properties GetProperties (string propertyName);
        List<Properties> GetAllProperties();
        void ReadFromFile ();
        void ReWriteToFile();
    }
}