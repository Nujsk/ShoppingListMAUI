using System.Windows.Input;
namespace UpggiftMAUI.ViewModels
{
    public class AppShellViewModel
    {
        public ICommand GoToMainCommand { get; }
        public ICommand GoToShoppingListsCommand { get; }

        public AppShellViewModel()
        {
            GoToMainCommand = new Command(async () => await Shell.Current.GoToAsync("//main"));
            GoToShoppingListsCommand = new Command(async () => await Shell.Current.GoToAsync("//shoppinglists"));
        }
    }
}
