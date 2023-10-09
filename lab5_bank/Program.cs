using System;
using System.Collections.Generic;
namespace lab5_bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, double> dict = new Dictionary<double, double>
            {
                { 0, 0.03 },
                { 50000, 0.035 },
                { 100000, 0.04 }
            };
            Bank Sber = new Bank(0.0365, 0.08, 200000, 20000, dict);
            Bank Sber2 = new Bank(0.0565, 0.02, 20000, 10000, dict);

            TimeLine CurrentTimeLine = new TimeLine(new List<Bank> { Sber, Sber2 });

            IClientBuilder clientBuilder = new CurrentClientBuilder();
            Client client1 = clientBuilder.SetFirstName("FirstName").SetSecondName("LastName").SetAdress("Adress").SetPassportNumber("123456").ClientBuild();
            Sber.AddClient(client1);
            Client client2 = clientBuilder.SetFirstName("First").SetSecondName("Last").SetAdress("Adress2").SetPassportNumber("123457").ClientBuild();
            Sber2.AddClient(client2);
            
            Account acc1 = Sber.AddCreditAccount(client1, 120000);
            Account acc2 = Sber.AddDebetAccount(client1, 120000);
            Account acc3 = Sber2.AddDepositAccount(client2, 120000, DateTime.Today.AddDays(4));
            Transaction tr = new WithdrawTransaction(130000, acc1);
            Sber.ExecuteTransaction(acc1, tr);
            Sber.ExecuteTransaction(acc1, new WithdrawTransaction(130000, acc1));
            Console.WriteLine(acc1.Money);
            Sber.UndoTransaction(acc1, tr);
            Console.WriteLine(acc1.Money);
            Sber.ExecuteTransaction(acc2, new DeposeTransaction(1000, acc2));
            try { Sber.ExecuteTransaction(acc2, new WithdrawTransaction(130000, acc2)); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine(acc2.Money);
            for(int i = 0; i < 5; i++)
            {
                CurrentTimeLine.NextDay();
            }
            Console.WriteLine(acc3.Money);
            Sber2.ExecuteTransaction(acc3, new DeposeTransaction(10000, acc3));
            try { Sber2.ExecuteTransaction(acc3, new TransferTransaction(130000, acc3,acc2)); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine(acc3.Money);
            Console.WriteLine(acc2.Money);
        }
    }
}
