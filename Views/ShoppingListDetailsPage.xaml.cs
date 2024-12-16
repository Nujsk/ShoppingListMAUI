using System.Collections.Generic;
using UpggiftMAUI.ViewModels;

namespace UpggiftMAUI.Views;

[QueryProperty(nameof(ListIdString), "listId")]
public partial class ShoppingListDetailsPage : ContentPage
{
    public string? ListIdString { get; set; }
    public ShoppingListDetailsPage(ShoppingListDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is ShoppingListDetailsViewModel vm)
        {
            if (Guid.TryParse(ListIdString, out Guid listId))
            {
                vm.Initialize(listId);
            }
        }
    }
}