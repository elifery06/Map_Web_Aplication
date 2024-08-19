using deneme1.Models;
using System.Collections.Generic;
 

namespace deneme1.Services
{
    
    public interface IItemService
    {
        List<Item> GetAllItems();
        Item GetItemById(int id);
        Response AddItem(Item item);
        Response UpdateItem(int id, Item updatedData);
        Response DeleteItem(int id);
    }
}
