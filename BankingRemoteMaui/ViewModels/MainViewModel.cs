using BankingRemoteApi.Models;
using BankingRemoteCore.Models;
using BankingRemoteMaui.Interfaces;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BankingRemoteMaui.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private IBankingService _bankingService;
        private IAlertDialogService _dialogService;


        private Client _currentClient;

        public Client CurrentClient
        {
            get { return _currentClient; }
            set
            {
                _currentClient = value;

                OnPropertyChanged();

            }
        }

        private BankAccount _bankAccount;

        public BankAccount FirstBankAccont
        {
            get { return _bankAccount; }
            set
            {
                _bankAccount = value;

                OnPropertyChanged();
            }
        }


        private ObservableCollection<Transaction> _transactions;

        public ObservableCollection<Transaction> Transactions
        {
            get { return _transactions; }
            set
            {
                _transactions = value;

                OnPropertyChanged();

            }
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();

            await LoadData();
        }

        public MainViewModel(IBankingService bankingService, IAlertDialogService dialogService)
        {
            _dialogService = dialogService;
            _bankingService = bankingService;
        }

        private async Task LoadData()
        {
            try
            {

                Client client = await _bankingService.VerifyLogin(new Auth() { Username = "Bob", Password = "12345" });


                CurrentClient = client;

                if (CurrentClient != null)
                {

                    FirstBankAccont = CurrentClient.BankAccounts.FirstOrDefault();

                    if (FirstBankAccont != null)
                    {
                        Transactions = new ObservableCollection<Transaction>(await _bankingService.GetTransactionsByBankAccountId(FirstBankAccont.BankAccountId));
                    }
                }
            }
            catch (Exception ex)
            {
                await _dialogService.ShowAlertAsync("Error", ex.Message, "Cancel");
            }
        }

        [RelayCommand]
        private async Task Reload()
        {
            await LoadData();

        }


        [RelayCommand]
        private async Task Save()
        {
            try
            {
                await _bankingService.UpdateClient(CurrentClient);

                await _dialogService.ShowAlertAsync("Success", "Client Saved", "Ok");
            }
            catch (Exception ex)
            {
                await _dialogService.ShowAlertAsync("Error", ex.Message, "Cancel");
            }

        }
    }
}

