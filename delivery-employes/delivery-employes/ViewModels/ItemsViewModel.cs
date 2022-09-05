using delivery_employes.Controllers;
using delivery_employes.Models;
using delivery_employes.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace delivery_employes.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public DeliveryControllers deliveryCtrl;

        private Delivery _selectedItem;

        public ObservableCollection<Delivery> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Delivery> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Pedidos";
            Items = new ObservableCollection<Delivery>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Delivery>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                deliveryCtrl = new DeliveryControllers();
                var items = await deliveryCtrl.AllDeliverys();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Delivery SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewDeliveryPage));
        }

        async void OnItemSelected(Delivery item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(UpdateDeliveryPage)}?{nameof(ItemUpdateViewModel.ItemId)}={item.Id}");
        }
    }
}