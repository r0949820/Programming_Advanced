using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VoorbeeldOrders.Data.Repository;
using VoorbeeldOrders.Models;

namespace VoorbeeldOrders.ViewModels
{
    public partial class OrdersViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Order> orders;

        private IOrderRepository _orderRepository;

        [ObservableProperty]
        private string bedrijfsnaam;

        public OrdersViewModel()
        {
            _orderRepository = new OrderRepository();
        }

        [RelayCommand]
        public void AlleOrdersOphalen()
        {
            IsBusy = true;
            Orders = new ObservableCollection<Order>(_orderRepository.OrdersOphalen());
            IsBusy = false;
        }

        [RelayCommand]
        public void AlleOrdersOphalenVoorKlant()
        {
            IsBusy = true;
            Orders = new ObservableCollection<Order>(_orderRepository.OrdersOphalenVoorKlant(bedrijfsnaam));
            IsBusy = false;
        }
    }
}