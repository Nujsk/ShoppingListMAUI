using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UpggiftMAUI.Models;
using UpggiftMAUI.Services;

namespace UpggiftMAUI.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IShoppingItemRepository _itemRepository;
        private readonly IShoppingListRepository _listRepository;
        private readonly IAppState _appState;


        [ObservableProperty]
        private ShoppingList _selectedShoppingList;

        [ObservableProperty]
        private string _activeListName;

        [ObservableProperty]
        private ObservableCollection<ShoppingItem> shoppingItems = new();


        public MainViewModel(IShoppingItemRepository repository, IAppState appstate, IShoppingListRepository listRepository)
        {
            _itemRepository = repository;
            _appState = appstate;
            LoadActiveListItems();
            _listRepository = listRepository;
        }

        public MainViewModel()
        {

        }

        private async void LoadActiveListItems()
        {
            if (_appState.ActiveShoppingListId == null)
            {
                ActiveListName = "No active list selected";
                ShoppingItems = new ObservableCollection<ShoppingItem>();
                return;
            }
            var activeList = await _listRepository.GetListByIdAsync(_appState.ActiveShoppingListId.Value);
            ActiveListName = activeList != null ? activeList.Name : "No active list selected";

            var items = await _itemRepository.GetByListIdAsync(_appState.ActiveShoppingListId.Value);
            ShoppingItems = new ObservableCollection<ShoppingItem>(items);
        }

        public void RefreshActiveListItems()
        {
            LoadActiveListItems();
        }
    }
}
