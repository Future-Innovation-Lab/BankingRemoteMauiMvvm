using BankingRemoteMaui.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingRemoteMaui.Services
{
    public class DefaultMauiAlertDialogService : IAlertDialogService
    {
        public async Task ShowAlertAsync(string title, string message, string cancel = "OK")
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert(title, message, cancel);
            }
        }

    }
}
