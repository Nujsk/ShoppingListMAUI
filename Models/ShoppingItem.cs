using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace UpggiftMAUI.Models
{
    public partial class ShoppingItem : ObservableObject
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Amount { get; set; }

        [ObservableProperty]
        public bool isBought;
        public Guid ListId { get; set; }

        public ShoppingItem()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }

        public ShoppingItem(string name, int amount, Guid listId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Amount = amount;
            ListId = listId;
        }
    }
}
