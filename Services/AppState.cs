using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpggiftMAUI.Services
{
    public class AppState : IAppState
    {
        public Guid? ActiveShoppingListId { get; set; }
    }
}
