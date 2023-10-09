using System;
using System.Collections.Generic;

namespace lab5_bank
{
    class DebetAccount : Account
    {
        public DebetAccount(double money, double remnantPercent, double suspiciousLimit, bool suspicious)
        {
            history = new List<Transaction>();
            ID = Guid.NewGuid();
            Blocked = false;
            Suspicious = suspicious;
            Money = money;
            RemnantPercent = remnantPercent;
            ComissionPercent = 0;
            CreditLimit = 0;
            SuspiciousLimit = suspiciousLimit;
            RemnantMoney = 0;
            DateLimit = DateTime.MinValue;
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
