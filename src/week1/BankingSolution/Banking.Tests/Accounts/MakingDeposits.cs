using Banking.Domain;
using Banking.Tests.TestDoubles;

namespace Banking.Tests.Accounts;
public class MakingDeposits
{
    [Fact]
    public void MakingADepositIncreasesBalanace()
    {
        // Given
        var account = new Account(new DummyBonusCalculator()); // <--- _balance = 5000
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.10M;

        // When
        account.Deposit(amountToDeposit);

        // Then
        var newBalance = account.GetBalance();
        Assert.Equal(amountToDeposit + openingBalance, account.GetBalance());
    }

    [Fact]
    public void CannotDepositNegativeNumbers()
    {
        var account = new Account(new DummyBonusCalculator());

        Assert.Throws<AccountNegativeTransactionAmountException>(() => account.Deposit(-1));
    }
}
