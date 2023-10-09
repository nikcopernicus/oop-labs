using System;
using System.Collections.Generic;
namespace lab5_bank
{
    class Bank
    {
        public List<Client> DataBase;
        public double RemnantPercent;
        public double ComissionPercent;
        public double CreditLimit;
        public double SuspiciousLimit;
        public Dictionary<double, double> MoneyPercent;
        public Bank(double remnantPercent, double comissionPercent, double creditLimit,double suspiciousLimit, Dictionary<double, double> moneyPercent)
        {
            DataBase = new List<Client>();
            RemnantPercent = remnantPercent;
            ComissionPercent = comissionPercent;
            CreditLimit = creditLimit;
            SuspiciousLimit = suspiciousLimit;
            MoneyPercent = moneyPercent;
        }
        public double DepositPercent(double money)
        {
            double percent = 0;
            foreach (var i in MoneyPercent)
            {
                if (money >= i.Key)
                {
                    percent = i.Value;
                }
                else
                {
                    break;
                }
            }
            return percent;
        }
        public void AddClient(Client client)
        {
            DataBase.Add(client);
        }
        public Account AddCreditAccount(Client client, double money)
        {
            Account account = new CreditAccount(money, ComissionPercent, CreditLimit, SuspiciousLimit, client.IsSuspicious());
            client.AddAccount(account);
            return account;
        }
        public Account AddDebetAccount(Client client, double money)
        {
            Account account = new DebetAccount(money, RemnantPercent, SuspiciousLimit, client.IsSuspicious());
            client.AddAccount(account);
            return account;
        }
        public Account AddDepositAccount(Client client, double money, DateTime dateLimit)
        {
            Account account = new DepositAccount(money, DepositPercent(money), SuspiciousLimit, client.IsSuspicious(), dateLimit);
            client.AddAccount(account);
            return account;
        }
        public void ExecuteTransaction(Account account, Transaction transaction)
        {
            account.ExecuteTransaction(transaction);
        }
        public void UndoTransaction(Account account, Transaction transaction)
        {
            account.UndoTransaction(transaction);
        }
    }
}
