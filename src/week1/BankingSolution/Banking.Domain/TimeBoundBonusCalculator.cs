namespace Banking.Domain;

public class TimeBoundBonusCalculator : ICalculateBonusesForDepositsOnAccounts
{

    public decimal CalculateBonusForDeposit(decimal balance, decimal depositAmount)
    {
        if(_businessClock.WeAreCurrentlyDuringBusinessHours())
        {
            return balance >= 5000 ? depositAmount * .10M : 0;
        } else
        {
            return 0;
        }
    }
}