namespace DddInPractice.Tests
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_Of_Two_Money_Producess_Correct_Result()
        {
            // Arrange
            Money m1 = new Money(1, 2, 3, 4, 5, 6);
            Money m2 = new Money(1, 2, 3, 4, 5, 6);

            // Act
            Money sum = m1 + m2;

            // Assert
            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCentCount.Should().Be(6);
            sum.OneDolarCount.Should().Be(8);
            sum.FiveDolarCount.Should().Be(10);
            sum.TwentyDolarCount.Should().Be(12);
        }

        [Fact]
        public void Two_Moneys_Are_Equal_When_Money_Amount_Is_Same()
        {
            Money m1 = new Money(1, 2, 3, 4, 5, 6);
            Money m2 = new Money(1, 2, 3, 4, 5, 6);

            m1.Should().Be(m2);
            m1.GetHashCode().Should().Be(m2.GetHashCode());
        }

        [Fact]
        public void Two_Moneys_Are_NOT_Equal_When_Money_Amount_Is_Not_Same()
        {
            Money m1 = new Money(0, 0, 0, 1, 0, 0);
            Money m2 = new Money(100, 0, 0, 0, 0, 0);

            m1.Should().NotBe(m2);
            m1.GetHashCode().Should().NotBe(m2.GetHashCode());
        }

        [Theory]
        [InlineData(-1,0,0,0,0,0)]
        [InlineData(0,-1,0,0,0,0)]
        [InlineData(0,0,-1,0,0,0)]
        [InlineData(0,0,0,-1,0,0)]
        [InlineData(0,0,0,0,-1,0)]
        [InlineData(0,0,0,0,0,-3)]
        public void Cannot_Create_Money_With_Negative_Value(
            int oneCentCount,
            int tenCentCount,
            int quarterCentCount,
            int oneDolarCount,
            int fiveDolarCount,
            int twentyDolarCount)
        {
            Action action = () => new Money(
                oneCentCount,
                tenCentCount,
                quarterCentCount,
                oneDolarCount,
                fiveDolarCount,
                twentyDolarCount
                );

            action.Should().Throw<InvalidOperationException>();
        }
    }
}