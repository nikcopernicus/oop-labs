using System;
using System.Collections.Generic;
namespace lab5_bank
{
    abstract class Account
    {
        public Guid ID;
        public List<Transaction> history;
        public bool Suspicious;
        public bool Blocked;
        public double Money;
        public double RemnantPercent;
        public double ComissionPercent;
        public double CreditLimit;
        public double SuspiciousLimit;
        public DateTime DateLimit;
        public double RemnantMoney;
        public abstract void AddRemnant();
        public abstract void RemnantToMoney();
        public bool IsSuspicious()
        {
            return Suspicious;
        }
        public bool IsBlocked()
        {
            return Blocked;
        }
        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
        }
        public void UndoTransaction(Transaction transaction)
        {
            transaction.Undo();
        }
    }
}
