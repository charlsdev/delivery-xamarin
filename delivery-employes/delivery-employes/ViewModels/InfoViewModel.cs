using delivery_employes.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace delivery_employes.ViewModels
{
    public class InfoViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public InfoViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(WelcomePage)}");
        }
    }
}
