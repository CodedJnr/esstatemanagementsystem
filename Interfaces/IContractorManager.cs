using System.Collections.Generic;
using Esstate_Management_System.Models;
namespace Esstate_Management_System.Interfaces
{
    public interface IContractorManager
    {
        public void CreateContractor (string name, string email, string pin, string phoneNumber);
        public void UpdateContractor (string name, string phoneNumber, string contractorId);
        public void DeleteContractor (string contractorId);
        public Contractor GetContractor (string contractorId);
        List<Contractor> GetAllContractor();
        public Contractor Login (string contractorId, string pin);
        void ReadFromFile ();
        void ReWriteToFile();
    }
}