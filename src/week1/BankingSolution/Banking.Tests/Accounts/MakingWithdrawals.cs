// Set breakpoints and right click on test and select debug to step through. Use immediate window to check values and run expressions.
using Banking.Domain;
using Banking.Tests.TestDoubles;

namespace Banking.Tests.Accounts;

public class MakingWithdrawals
{
    [Theory]
    [InlineData(3.23)]
    [InlineData(42.23)]
    public void MakingWithdrawalsDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new Account(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, 
            account.GetBalance());
    }

    [Fact]
    public void CannotMakeWithdrawalWithNegativeNumbers()
    {
        var account = new Account(new DummyBonusCalculator());
        Assert.Throws<AccountNegativeTransactionAmountException>(() => account.Withdraw(-3));
    }

    [Fact]
    public void CanWithdrawFullBalance()
    {
      var account = new Account(new DummyBonusCalculator());

        account.Withdraw(account.GetBalance());

      Assert.Equal(0, account.GetBalance());
    }

    [Fact]
    public void WhenOverdraftBalanceIsNotReducedNotAllowed()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountThatRepresentsMoreThanTheCurrentBalance = openingBalance + .01M;

        try
        {
            account.Withdraw(amountThatRepresentsMoreThanTheCurrentBalance);
        } catch (AccountTransactionException)
        {

        }

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void WhenOverdraftMethodThrows()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountThatRepresentsMoreThanTheCurrentBalance = openingBalance + .01M;
        //var exceptionThrow = false;

        //try
        //{
        //    account.Withdraw(amountThatRepresentsMoreThanTheCurrentBalance );
        //}
        //catch (AccountOverdraftException)
        //{
        //    exceptionThrow = true;
        //}
        //Assert.True(exceptionThrow);

        Assert.Throws<AccountOverdraftException>(() => account.Withdraw(amountThatRepresentsMoreThanTheCurrentBalance));
    }
}

