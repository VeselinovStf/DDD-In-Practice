namespace DddInPractice.Logic
{
    public sealed class SnackMachine
    {

        public Money MoneyInside { get; private set; } = 
            new Money(0, 0, 0, 0, 0, 0);
        public Money MoneyInTransaction { get; private set; } = 
            new Money(0, 0, 0, 0, 0, 0);

        public void InsertMoney(Money insertedMoney)
        {
            this.MoneyInTransaction += insertedMoney;
        }

        public void ReturnMoneyBack()
        {
            this.MoneyInTransaction = new Money(0,0,0,0,0,0);
        }

        public void BuySnack()
        {
            this.MoneyInside += MoneyInTransaction;             

            this.MoneyInTransaction = new Money(0, 0, 0, 0, 0, 0);
        }
    }
}