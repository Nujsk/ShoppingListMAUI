using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpggiftMAUI.Services
{
    public interface IAppState
    {
        Guid? ActiveShoppingListId { get; set; }
    }
}
