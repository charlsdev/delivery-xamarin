using delivery_employes.Controllers;
using delivery_employes.Models;
using delivery_employes.ViewModels;
using delivery_employes.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace delivery_employes.Views
{
    public partial class AllDeliveryPage : ContentPage
    {
        public DeliveryControllers deliveryCtrl;

        ItemsViewModel _viewModel;

        public AllDeliveryPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void DeletePedido_Clicked(object sender, EventArgs e)
        {
            deliveryCtrl = new DeliveryControllers();
            Button param = (Button)sender;
            string id = param.CommandParameter.ToString();

            var opt = await DisplayAlert("Información", "Deseas eliminar el pedido con id: " + id, "Sí", "No");

            if (opt)
            {
                bool status = await deliveryCtrl.DeletePedido(id);

                if (status)
                {
                    await DisplayAlert("Información", "Pedido eliminado con éxito.", "OK");

                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Información", "Pedido no eliminado.", "OK");
                }
            }
            else
            {
                return;
            }
        }
    }
}