using CommunityToolkit.Mvvm.ComponentModel;

namespace UpggiftMAUI.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        public string? title;
    }
}
