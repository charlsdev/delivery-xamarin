using delivery_employes.Controllers;
using delivery_employes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace delivery_employes.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public DeliveryControllers deliveryCtrl;

        private string cedula;
        private string nameCompleto;
        private string direccion;
        private string estado;
        private string producto;
        private string precio;
        private string cantidad;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(cedula)
                && !String.IsNullOrWhiteSpace(nameCompleto)
                && !String.IsNullOrWhiteSpace(direccion)
                && !String.IsNullOrWhiteSpace(estado)
                && !String.IsNullOrWhiteSpace(producto)
                && !String.IsNullOrWhiteSpace(precio)
                && !String.IsNullOrWhiteSpace(cantidad);
        }

        public string Cedula
        {
            get => cedula;
            set => SetProperty(ref cedula, value);
        }

        public string NameCompleto
        {
            get => nameCompleto;
            set => SetProperty(ref nameCompleto, value);
        }

        public string Direccion
        {
            get => direccion;
            set => SetProperty(ref direccion, value);
        }

        public string Estado
        {
            get => estado;
            set => SetProperty(ref estado, value);
        }

        public string Producto
        {
            get => producto;
            set => SetProperty(ref producto, value);
        }

        public string Precio
        {
            get => precio;
            set => SetProperty(ref precio, value);
        }

        public string Cantidad
        {
            get => cantidad;
            set => SetProperty(ref cantidad, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            deliveryCtrl = new DeliveryControllers();

            bool status = await deliveryCtrl.SavePedido(
                                                    Cedula,
                                                    NameCompleto,
                                                    Direccion,
                                                    Estado,
                                                    Producto,
                                                    Precio,
                                                    Cantidad
                                                );

            if (status)
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
