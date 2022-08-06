namespace DddInPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; private set; }
        public int TenCentCount { get; private set; }
        public int QuarterCentCount { get; private set; }
        public int OneDolarCount { get; private set; }
        public int FiveDolarCount { get; private set; }
        public int TwentyDolarCount { get; private set ; }

        public Money(
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDolarCount,
            int fiveDolarCount,
            int twentyDolarCount)
        {
            this.OneCentCount = oneCentCount;
            this.TenCentCount = tenCentCount;
            this.QuarterCentCount = quarterCentCount;
            this.OneDolarCount = oneDolarCount;
            this.FiveDolarCount = fiveDolarCount;
            this.TwentyDolarCount = twentyDolarCount;
        }

        public static Money operator +(Money a, Money b){
           return new Money(
              a.OneCentCount + b.OneCentCount,
              a.TenCentCount + b.TenCentCount,
              a.QuarterCentCount + b.QuarterCentCount,
              a.OneDolarCount + b.OneDolarCount,
              a.FiveDolarCount + b.FiveDolarCount,
              a.TwentyDolarCount + b.TwentyDolarCount
              );

        }

        protected override bool EqualsStructural(Money other)
        {
            return OneCentCount == other.OneCentCount
              && TenCentCount == other.TenCentCount
              && QuarterCentCount == other.QuarterCentCount
              && OneDolarCount == other.OneDolarCount
              && FiveDolarCount == other.FiveDolarCount
              && TwentyDolarCount == other.TwentyDolarCount;
        }

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
