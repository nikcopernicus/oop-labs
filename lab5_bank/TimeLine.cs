using System;
using System.Collections.Generic;
namespace lab5_bank
{
    class TimeLine
    {
        List<Bank> Banks;
        public DateTime Time;
        public TimeLine(List<Bank> banks)
        {
            Banks = new List<Bank>(banks);
            Time = DateTime.Today;
        }
        public void NextDay()
        {
            foreach(Bank bank in Banks)
            {
                foreach(Client client in bank.DataBase)
                {
                    foreach (Account account in client.Accounts)
                    {
                        account.AddRemnant();
                        if (IsNewMonth(Time.AddDays(1)))
                        {
                            account.RemnantToMoney();
                        }
                        if(account.DateLimit == Time.AddDays(1))
                        {
                            account.DateLimit = DateTime.MinValue;
                        }
                    }
                }
            }
            Time = Time.AddDays(1);
        }
        public bool IsNewMonth(DateTime time)
        {
            if (Time.Month != time.Month)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
