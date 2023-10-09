using System.Collections.Generic;
namespace lab5_bank
{
    class DeposeTransaction : Transaction
    {
        Account FromAcc;
        public DeposeTransaction(double money, Account fromAcc)
        {
            Money = money;
            FromAcc = fromAcc;
        }
        public override void Execute()
        {
            FromAcc.history.Add(this);
            FromAcc.Money += Money;
        }

        public override void Undo()
        {
            FromAcc.Money -= Money;
            FromAcc.history.Remove(this);
        }
    }
}
