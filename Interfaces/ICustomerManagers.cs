using System.Collections.Generic;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Interfaces
{
    public interface ICustomerManager
    {
        void CreateCustomer(string name, string email, string phoneNumber, string pin, string address);
        Customer GetCustomer(string customerId);
        List<Customer> GetAllCustomer();
        void UpdateCustomer(string customerId, string name, string phoneNumber);
        void DeleteCustomer(string customerId);
        Customer Login (string customerId,  string pin);
        void ReadFromFile ();
        void ReWriteToFile();
    }
}