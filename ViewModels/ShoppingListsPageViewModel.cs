using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UpggiftMAUI.Models;
using UpggiftMAUI.Services;

namespace UpggiftMAUI.ViewModels
{
    public partial class ShoppingListsPageViewModel : ViewModelBase
    {
        private readonly IShoppingListRepository _listRepository;
        private readonly IAppState _appstate;

        [ObservableProperty]
        private string newListName;

        [ObservableProperty]
        private ObservableCollection<ShoppingList> shoppingLists = new();

        public ShoppingListsPageViewModel(IShoppingListRepository listRepository, IAppState appState)
        {
            _listRepository = listRepository;
            _appstate = appState;
            LoadListsCommand = new AsyncRelayCommand(LoadListsAsync);
            LoadListsCommand.ExecuteAsync(null);
        }

        public IAsyncRelayCommand LoadListsCommand { get; }

        private async Task LoadListsAsync()
        {
            var lists = await _listRepository.GetAllAsync();
            ShoppingLists = new ObservableCollection<ShoppingList>(lists);
        }

        [RelayCommand]
        private async Task AddListAsync()
        {
            if (string.IsNullOrWhiteSpace(NewListName))
            {
                return;
            }
            var newList = new ShoppingList(NewListName);
            await _listRepository.AddAsync(newList);

            ShoppingLists.Add(newList);
            NewListName = string.Empty;
        }

        [RelayCommand]
        private async Task SetActiveAsync(ShoppingList list)
        {
            if (list == null)
            {
                return;
            }
            _appstate.ActiveShoppingListId = list.Id;
            await Shell.Current.GoToAsync("//main");
        }

        [RelayCommand]
        private async Task EditListAsync(ShoppingList list)
        {
            if (list == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"//listdetails?listId={list.Id}");
        }
    }
}
