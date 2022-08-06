namespace DddInPractice.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Returns_Moneys_Empties_Money_In_Transaction()
        {
            var sut = new SnackMachine();
            sut.InsertMoney(Money.Dolar);

            sut.ReturnMoneyBack();

            sut.MoneyInTransaction.Amount.Should().Be(0);
        }

        [Fact]
        public void Insert_Moneys_Should_Go_In_Transaction()
        {
            var sut = new SnackMachine();
            sut.InsertMoney(Money.Dolar);

            sut.MoneyInTransaction.Amount.Should().Be(1);
        }
    }
}
