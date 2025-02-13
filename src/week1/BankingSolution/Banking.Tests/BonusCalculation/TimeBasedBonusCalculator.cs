using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain;

namespace Banking.Tests.BonusCalculation;
public class TimeBasedBonusCalculator
{
    [Theory]
    [InlineData(5000, 100, 20)]
    [InlineData(5000, 200, 40)]
    [InlineData(10000, 200, 40)]
    public void BonusesThatMeetThresholdGetBonusIfDuringBusinessHours(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var bonusCalculator = new TimeBoundBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }

    [Theory]
    [InlineData(5000, 100, 20)]
    [InlineData(5000, 200, 40)]
    [InlineData(10000, 200, 40)]
    public void BonusesThatMeetThresholdGetNoBonusOutisideBusinessHours(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }

    [Theory]
    [InlineData(5, 100, 0)]
    [InlineData(499.99, 200, 0)]
    [InlineData(0, 1000, 0)]
    public void BonusBelowThresholdGetNoBonus(decimal balance, decimal depositAmount, decimal expectedBonus)
    {
        var bonusCalculator = new TimeBoundBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForDeposit(balance, depositAmount);

        Assert.Equal(expectedBonus, bonus);
    }
}
