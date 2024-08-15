using deneme1.Models;
using System.Collections.Generic;
 

namespace deneme1.Services
{
    
    public interface IItemService
    {
        List<Item> GetAllItems();
        Item GetItemById(int id);
        Response<Item> AddItem(Item item);
        Response<Item> UpdateItem(int id, Item updatedData);
        Response<Item> DeleteItem(int id);
    }
}
