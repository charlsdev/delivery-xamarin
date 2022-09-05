using delivery_employes.Models;
using delivery_employes.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace delivery_employes.Views
{
    public partial class NewDeliveryPage : ContentPage
    {
        public Delivery Item { get; set; }

        public NewDeliveryPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}