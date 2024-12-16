
using SQLite;
using System.Text.Json;

namespace UpggiftMAUI.Models
{
    public class ShoppingList
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ShoppingList()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }

        public ShoppingList(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
