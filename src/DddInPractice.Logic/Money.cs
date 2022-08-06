namespace DddInPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);

        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money QuarterCent = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dolar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDolar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDolar = new Money(0, 0, 0, 0, 0, 1);

        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCentCount { get; }
        public int OneDolarCount { get; }
        public int FiveDolarCount { get; }
        public int TwentyDolarCount { get; }

        public decimal Amount => OneCentCount * 0.01m +
                    TenCentCount * 0.10m +
                    QuarterCentCount * 0.25m +
                    OneDolarCount +
                    FiveDolarCount * 5 +
                    TwentyDolarCount * 20;

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDolarCount,
            int fiveDolarCount,
            int twentyDolarCount)
        {
            this.OneCentCount = oneCentCount < 0 ? throw new InvalidOperationException() : oneCentCount;
            this.TenCentCount = tenCentCount < 0 ? throw new InvalidOperationException() : tenCentCount;
            this.QuarterCentCount = quarterCentCount < 0 ? throw new InvalidOperationException() : quarterCentCount;
            this.OneDolarCount = oneDolarCount < 0 ? throw new InvalidOperationException() : oneDolarCount;
            this.FiveDolarCount = fiveDolarCount < 0 ? throw new InvalidOperationException() : fiveDolarCount;
            this.TwentyDolarCount = twentyDolarCount < 0 ? throw new InvalidOperationException() : twentyDolarCount;
        }

        public static Money operator +(Money a, Money b) => 
            new Money(
               a.OneCentCount + b.OneCentCount,
               a.TenCentCount + b.TenCentCount,
               a.QuarterCentCount + b.QuarterCentCount,
               a.OneDolarCount + b.OneDolarCount,
               a.FiveDolarCount + b.FiveDolarCount,
               a.TwentyDolarCount + b.TwentyDolarCount
            );

        public static Money operator -(Money a, Money b) =>
           new Money(
              a.OneCentCount - b.OneCentCount,
              a.TenCentCount - b.TenCentCount,
              a.QuarterCentCount - b.QuarterCentCount,
              a.OneDolarCount - b.OneDolarCount,
              a.FiveDolarCount - b.FiveDolarCount,
              a.TwentyDolarCount - b.TwentyDolarCount
           );

        protected override bool EqualsStructural(Money other) => 
                 OneCentCount == other.OneCentCount
              && TenCentCount == other.TenCentCount
              && QuarterCentCount == other.QuarterCentCount
              && OneDolarCount == other.OneDolarCount
              && FiveDolarCount == other.FiveDolarCount
              && TwentyDolarCount == other.TwentyDolarCount;

        protected override int GetHashCodeInternal()
        {
            unchecked
            {
                int hashCode = OneCentCount;

                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuarterCentCount;
                hashCode = (hashCode * 397) ^ OneDolarCount;
                hashCode = (hashCode * 397) ^ FiveDolarCount;
                hashCode = (hashCode * 397) ^ TwentyDolarCount;

                return hashCode;
            }
        }
    }
}
