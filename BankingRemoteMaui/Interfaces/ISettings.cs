namespace BankingRemoteMaui.Interfaces
{
    public interface ISettings
    {
        string ServerAddress { get; }
        string AuthControllerRoute { get; }
        string TransactionControllerRoute { get; }
        string BankAccountControllerRoute { get; }
        string ClientControllerRoute { get; }
    }
}
