using UpggiftMAUI.ViewModels;

namespace UpggiftMAUI.Views;

public partial class ShoppingListsPage : ContentPage
{
	public ShoppingListsPage(ShoppingListsPageViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ShoppingListsPageViewModel)?.LoadListsCommand.Execute(null);
    }
}