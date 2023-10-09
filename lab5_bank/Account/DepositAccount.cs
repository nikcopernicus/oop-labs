using System;
using System.Collections.Generic;

namespace lab5_bank
{
    class DepositAccount : Account
    {
        public DepositAccount(double money, double remnantPercent, double suspiciousLimit, bool suspicious, DateTime dateLimit)
        {
            history = new List<Transaction>();
            ID = Guid.NewGuid();
            Blocked = false;
            Suspicious = suspicious;
            Money = money;
            RemnantPercent = remnantPercent;
            ComissionPercent = 0;
            CreditLimit = 0;
            RemnantMoney = 0;
            SuspiciousLimit = suspiciousLimit;
            DateLimit = dateLimit;
        }
        public override void AddRemnant()
        {
            RemnantMoney += RemnantPercent * Money;
        }
        public override void RemnantToMoney()
        {
            Money += RemnantMoney;
            RemnantMoney = 0;
        }
    }
}
