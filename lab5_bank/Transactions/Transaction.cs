using System;
namespace lab5_bank
{
    abstract class Transaction
    {
        public Guid ID;
        public double Money;
        public abstract void Execute();
        public abstract void Undo();
    }
}
