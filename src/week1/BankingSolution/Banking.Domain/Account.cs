namespace Banking.Domain
{
    // Right click Banking.Tests Dependencies and add project reference and add using Banking.Domain; to cs file
    public class Account // Switched from internal to publing taking it from accessible from only this project to accessible from other projects
    {
        private decimal _openingBalance = 5000;

        public void Deposit(decimal amountToDeposit)
        {
            _openingBalance += amountToDeposit;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _openingBalance -= amountToWithdraw;
        }

        public decimal GetBalance()
        {
            return _openingBalance;
        }
    }
}
