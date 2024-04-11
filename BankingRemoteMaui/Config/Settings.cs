using BankingRemoteMaui.Interfaces;

namespace BankingRemoteMaui.Config
{
    public class Settings : ISettings
    {
        //https://localhost:7053/api/Auth

        public string ServerAddress
        { get { return "https://10.0.2.2:7053"; } }

        public string AuthControllerRoute
        { get { return "/api/Auth/"; } }

        public string TransactionControllerRoute
        { get { return "/api/Transaction"; } }

        public string BankAccountControllerRoute
        { get { return "/api/BankAccount"; } }

        public string ClientControllerRoute
        { get { return "/api/Client"; } }

    }
}
