using Banking.Domain;

namespace Banking.Tests.Accounts;
public class NewAccounts
{
    [Fact]
    public void BalanaceIsCorrect()
    {
        var correctOpeningBalance = 5000M;
        // To create new class do CTRL + . and selecte generate new type. Will create class, add project reference, and add using
        var myAccount = new Account();
        var yourAccount = new Account();

        var myBalance = myAccount.GetBalance(); 
        decimal yourBalance = yourAccount.GetBalance(); // Quick hints can generate method since type is specified

        Assert.Equal(correctOpeningBalance, myAccount.GetBalance());
        Assert.Equal(correctOpeningBalance, yourAccount.GetBalance());
    }
}
