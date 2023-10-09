using System;
using System.Collections.Generic;
namespace lab5_bank
{
    class Client
    {
        public List<Account> Accounts;
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
        public Client(string firstName, string secondName, string adress, string passportNumber)
        {
            Accounts = new List<Account>();
            FirstName = firstName;
            SecondName = secondName;
            Adress = adress;
            PassportNumber = passportNumber;
            if (FirstName == null || SecondName == null)
            {
                throw new Exception("Error: Client must have FirstName and LastName");
            }
            else
            {
                if (Adress == null || PassportNumber == null)
                {
                    Suspicious = true;
                }
                else
                {
                    Suspicious = false;
                }
            }
        }
        public bool IsSuspicious()
        {
            return Suspicious;
        }
        public void SetAdress(string adress)
        {
            Adress = adress;
            if (PassportNumber != null)
            {
                foreach(Account account in Accounts)
                {
                    account.Suspicious = false;
                }
                Suspicious = false;
            }
            else
            {
                Suspicious = true;
            }
        }
        public void SetPassportNumber(string passportNumber) 
        {
            PassportNumber = passportNumber;
            if (Adress != null)
            {
                Suspicious = false;
            }
            else
            {
                Suspicious = true;
            }
        }
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string Adress { get; set; }
        private string PassportNumber { get; set; }
        private bool Suspicious { get; set; }
    }
}
