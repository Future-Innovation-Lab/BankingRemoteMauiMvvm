using BankingRemoteMaui.ViewModels;

namespace BankingRemoteMaui
{
    public partial class MainView : ContentPage
    {
        private BaseViewModel _viewModel;

        public MainView(MainViewModel vm)
        {
            InitializeComponent();

            _viewModel = vm;

            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.OnAppearing();


        }
    }
}
