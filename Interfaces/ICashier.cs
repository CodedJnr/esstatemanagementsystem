using System.Collections.Generic;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Interfaces
{
    public interface ICashier
    {
        public void MakePurchase(string Email, string choiceAddress, string paymentStatus, double totalPrice);
        public void DeletePurchase(int id);
        public Cashier GetPurchase(int id);
        List<Cashier> GetAllPurchases();
        public void StatusToReady(int id); 
        void ReadFromFile ();
        void ReWriteToFile(); 
    }
}