﻿using System;
using System.Collections.Generic;
namespace lab5_bank
{
    class TransferTransaction : Transaction
    {
        Account FromAcc;
        Account ToAcc;
        public TransferTransaction(double money, Account fromAcc, Account toAcc)
        {
            ID = Guid.NewGuid();
            Money = money;
            FromAcc = fromAcc;
            ToAcc = toAcc;
        }
        public override void Execute()
        {
            if (FromAcc.DateLimit <= DateTime.Today)
            {
                if (FromAcc.IsSuspicious())
                {
                    if (FromAcc.SuspiciousLimit < Money)
                    {
                        throw new Exception("Error: Unable to do transaction cause you have not full regitered yet, and your transaction is limited");
                    }
                }
            }
            else
            {
                throw new Exception("Error: Unable to do transaction cause DateLimit");
            }
            if (FromAcc.Money + FromAcc.CreditLimit < Money)
            {
                throw new Exception("Error: Unable to do transaction cause not enough money");
            }
            else
            {
                if (FromAcc.Money < 0)
                {
                    Money *= (1 + FromAcc.ComissionPercent);
                }
                FromAcc.history.Add(this);                
                FromAcc.Money -= Money;
                ToAcc.history.Add(this);                
                ToAcc.Money += Money;
            }
        }

        public override void Undo()
        {
            FromAcc.Money += Money;
            ToAcc.Money -= Money;
            FromAcc.history.Remove(this);
            ToAcc.history.Remove(this);
        }
    }
}
