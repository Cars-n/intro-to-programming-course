using Banking.Domain;

namespace Banking.Tests.Accounts;
public class MakingDeposits
{
    [Fact]
    public void MakingADepositIncreasesBalanace()
    {
        // Given
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100.10M;

        // When
        account.Deposit(amountToDeposit);

        // Then
        var newBalance = account.GetBalance();
        Assert.Equal(amountToDeposit + openingBalance, account.GetBalance());
    }
}
