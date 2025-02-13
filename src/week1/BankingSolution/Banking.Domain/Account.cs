namespace Banking.Domain;

// Right click Banking.Tests Dependencies and add project reference and add using Banking.Domain; to cs file
public class Account // Switched from internal to public taking it from accessible from only this project to accessible from other projects
{
    private ICalculateBonusesForDepositsOnAccounts _bonusCalculator;

    public Account(ICalculateBonusesForDepositsOnAccounts bonusCalculator)
    {
        _currentBalance = 5000M;
        _bonusCalculator = bonusCalculator;
    }

    private decimal _currentBalance;

    // Queries - where we ask for stuff
    public decimal GetBalance()
    {
        return _currentBalance;
    }

    // Commands - telling account to do work
    public void Deposit(decimal amountToDeposit) // virtual makes method overridable by children classes
    {
        CheckTransactionAmount(amountToDeposit);

        var bonus = _bonusCalculator.CalculateBonusForDeposit(_currentBalance, amountToDeposit);
        _currentBalance += amountToDeposit + bonus;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        CheckTransactionAmount(amountToWithdraw);
        if (_currentBalance >= amountToWithdraw)
        {
            _currentBalance -= amountToWithdraw;
        }
        else
        {
            throw new AccountOverdraftException(); 
        }
    }

    // Helpers, etc. extracted from above
    private void CheckTransactionAmount(decimal amount)
    {
        if (amount < 0)
        {
            throw new AccountNegativeTransactionAmountException();
        }
    }
}