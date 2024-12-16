using UpggiftMAUI.ViewModels;
using UpggiftMAUI.Models;

namespace UpggiftMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as MainViewModel)?.RefreshActiveListItems();
        }
    }
}
