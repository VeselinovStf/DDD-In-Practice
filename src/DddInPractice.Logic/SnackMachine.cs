namespace DddInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInside { get; private set; } = Money.None;
        public Money MoneyInTransaction { get; private set; } = Money.None;

        public void InsertMoney(Money insertedMoney)
        {
            Money[] coinsAndBills =
            {
                Money.Cent, Money.TenCent, Money.QuarterCent,
                Money.Dolar, Money.FiveDolar, Money.TwentyDolar
            };

            if (!coinsAndBills.Contains(insertedMoney))
            {
                throw new InvalidOperationException();
            }

            this.MoneyInTransaction += insertedMoney;
        }

        public void ReturnMoneyBack()
        {
            this.MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            // TODO: Deal with snack no whole transaction
            this.MoneyInside += MoneyInTransaction;             

            this.MoneyInTransaction = Money.None;
        }
    }
}