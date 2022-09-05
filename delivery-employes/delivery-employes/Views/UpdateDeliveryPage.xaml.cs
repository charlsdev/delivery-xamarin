using delivery_employes.ViewModels;
using System.ComponentModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace delivery_employes.Views
{
    public partial class UpdateDeliveryPage : ContentPage
    {
        public UpdateDeliveryPage()
        {
            InitializeComponent();
            BindingContext = new ItemUpdateViewModel();
        }
    }
}