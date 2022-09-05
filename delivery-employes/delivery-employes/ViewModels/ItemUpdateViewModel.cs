using delivery_employes.Controllers;
using delivery_employes.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace delivery_employes.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemUpdateViewModel : BaseViewModel
    {
        public DeliveryControllers deliveryCtrl;

        public string Id { get; set; }

        private string id;
        private string cedula;
        private string nameCompleto;
        private string direccion;
        private string estado;
        private string producto;
        private string precio;
        private string cantidad;

        public ItemUpdateViewModel()
        {
            UpdateCommand = new Command(OnUpdate, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => UpdateCommand.ChangeCanExecute();
        }

        public Command UpdateCommand { get; }
        public Command CancelCommand { get; }

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

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public string ItemId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnePedidoSearch(value);
            }
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

        public async void OnePedidoSearch(string itemId)
        {
            try
            {
                deliveryCtrl = new DeliveryControllers();
                Delivery items = await deliveryCtrl.OnePedido(itemId);

                Debug.WriteLine(items.Cedula);

                Cedula = items.Cedula;
                NameCompleto = items.NameCompleto;
                Direccion = items.Direccion;
                Estado = items.Estado;
                Producto = items.Producto;
                Precio = items.Precio;
                Cantidad = items.Cantidad;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to Load Item" + e);
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void OnUpdate()
        {
            deliveryCtrl = new DeliveryControllers();

            bool status = await deliveryCtrl.UpdatePedido(
                                                    ItemId,
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
