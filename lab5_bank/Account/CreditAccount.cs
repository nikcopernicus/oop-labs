using System;
using System.Collections.Generic;
namespace lab5_bank
{
    class CreditAccount : Account
    {
        public CreditAccount(double money,double comission,double creditLimit,double suspiciousLimit,bool suspicious)
        {
            history = new List<Transaction>();
            ID = Guid.NewGuid();
            Blocked = false;
            Suspicious = suspicious;
            Money = money;
            RemnantPercent = 0;
            ComissionPercent = comission;
            CreditLimit = creditLimit;
            SuspiciousLimit = suspiciousLimit;
            RemnantMoney = 0;
            DateLimit = DateTime.MinValue;
        }

        public override void AddRemnant()
        {
            return;
        }

        public override void RemnantToMoney()
        {
            return;
        }
    }
}
