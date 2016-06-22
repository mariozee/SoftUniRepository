namespace BankOfKurotovoKonare.Interfaces
{
    interface IAccount
    {
        string CustomerName { get; }

        double InterestRate { get; }
        
        double Balance { get; } 

        double InterestCalculator(int month);       
    }
}
