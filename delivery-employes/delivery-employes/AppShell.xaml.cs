using delivery_employes.ViewModels;
using delivery_employes.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace delivery_employes
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(UpdateDeliveryPage), typeof(UpdateDeliveryPage));
            Routing.RegisterRoute(nameof(NewDeliveryPage), typeof(NewDeliveryPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//InfoPage");
        }
    }
}
