namespace DddInPractice.Logic
{
    public sealed class SnackMachine
    {

        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCentCount { get; private set; }
        public int OneDolarCount { get; private set; }
        public int FiveDolarCount { get; private set; }
        public int TwentyDolarCount { get; private set; }

        public int OneCentCountTransaction { get; private set; }
        public int TenCentCountTransaction { get; private set; }
        public int QuarterCentCountTransaction { get; private set; }
        public int OneDolarCountTransaction { get; private set; }
        public int FiveDolarCountTransaction { get; private set; }
        public int TwentyDolarCountTransaction { get; private set; }

        public void InsertMoney(
            int oneCentCount, 
            int tenCentCount, 
            int quarterCentCount, 
            int oneDolarCount,
            int fiveDolarCount,
            int twentyDolarCount)
        {
            this.OneCentCountTransaction += oneCentCount;
            this.TenCentCountTransaction += tenCentCount;
            this.QuarterCentCountTransaction += quarterCentCount;
            this.OneDolarCountTransaction += oneDolarCount;
            this.FiveDolarCountTransaction += fiveDolarCount;
            this.TwentyDolarCountTransaction += twentyDolarCount;
        }

        public void ReturnMoneyBack()
        {
            this.OneCentCountTransaction = 0;
            this.TenCentCountTransaction = 0;
            this.QuarterCentCountTransaction = 0;
            this.OneDolarCountTransaction = 0;
            this.FiveDolarCountTransaction = 0;
            this.TwentyDolarCountTransaction = 0;
        }

        public void BuySnack()
        {
            this.OneCentCount += OneCentCountTransaction;
            this.TenCentCount += TenCentCountTransaction;
            this.QuarterCentCount += QuarterCentCountTransaction;
            this.OneDolarCount += OneDolarCountTransaction;
            this.FiveDolarCount += FiveDolarCountTransaction;
            this.TwentyDolarCount += TwentyDolarCountTransaction;

            this.OneCentCountTransaction = 0;
            this.TenCentCountTransaction = 0;
            this.QuarterCentCountTransaction = 0;
            this.OneDolarCountTransaction = 0;
            this.FiveDolarCountTransaction = 0;
            this.TwentyDolarCountTransaction = 0;
        }
    }
}