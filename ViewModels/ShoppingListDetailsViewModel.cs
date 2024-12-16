using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UpggiftMAUI.Models;
using UpggiftMAUI.Services;

namespace UpggiftMAUI.ViewModels
{
    public partial class ShoppingListDetailsViewModel : ViewModelBase
    {
        private readonly IShoppingListRepository _listRepository;
        private readonly IShoppingItemRepository _itemRepository;

        [ObservableProperty]
        private string listName;

        [ObservableProperty]
        private ObservableCollection<ShoppingItem> items = new();

        [ObservableProperty]
        private string newItemName;

        [ObservableProperty]
        private string newItemAmount;

        private Guid _listId;

        public ShoppingListDetailsViewModel(IShoppingListRepository listRepository,
            IShoppingItemRepository itemRepository)
            {
                _listRepository = listRepository;
                _itemRepository = itemRepository;
            }

        public void Initialize(Guid listId)
        {
            _listId = listId;
            _ = LoadListAsync();
        }

        private async Task LoadListAsync()
        {
            var list = await _listRepository.GetListByIdAsync(_listId);
            if (list != null)
            {
                ListName = list.Name;
                var listItems = await _itemRepository.GetByListIdAsync(_listId);
                Items = new ObservableCollection<ShoppingItem>(listItems);
            }
            else
            {
                return;
            }
        }

        [RelayCommand]
        private async Task AddItemAsync()
        {
            if (string.IsNullOrWhiteSpace(NewItemName) || string.IsNullOrWhiteSpace(NewItemAmount))
            {
                return;
            }

            if (!int.TryParse(NewItemAmount, out int amount))
            {
                return;
            }

            var newItem = new ShoppingItem(NewItemName, amount, _listId);
            await _itemRepository.AddAsync(newItem);
            Items.Add(newItem);

            NewItemName = string.Empty;
            NewItemAmount = string.Empty;
        }

        [RelayCommand]
        private async Task RemoveItemAsync(ShoppingItem item)
        {
            if (item == null)
            {
                return;
            } 
            await _itemRepository.DeleteAsync(item);
            Items.Remove(item);
        }

        [RelayCommand]
        private async Task SaveListAsync()
        {
            var list = await _listRepository.GetListByIdAsync(_listId);
            if(list == null)
            {
                return;
            }
            list.Name = ListName;
            await _listRepository.UpdateAsync(list);
            await Shell.Current.GoToAsync("//main");
        }

        [RelayCommand]
        private async Task DeleteListAsync()
        {
            var list = await _listRepository.GetListByIdAsync(_listId);
            if(list == null)
            {
                return;
            }
            var listItems = await _itemRepository.GetByListIdAsync(_listId);
            foreach (var item in listItems)
            {
                await _itemRepository.DeleteAsync(item);
            }

            await _listRepository.DeleteAsync(list);
            await Shell.Current.GoToAsync("//shoppinglists");
        }
    }
}
