using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace delivery_employes.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel()
        {
            Title = "Bienvenido";
        }

        public ICommand OpenWebCommand { get; }
    }
}