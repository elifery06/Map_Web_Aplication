using deneme1.Models;

namespace deneme1.Services
{
    public class ItemService : IItemService
    {
        private static List<Item> _items = new List<Item>();

        public List<Item> GetAllItems()
        {
          return _items;
        }
        
        public Item GetItemById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public Response<Item> AddItem(Item item)
        {
            _items.Add(item);
            return new Response<Item>(item, true, "Item başarıyla eklendi");
        }
        public Response<Item> UpdateItem(int id, Item updatedData)
        {
           var selectedItem = _items.FirstOrDefault(x => x.Id == id);
            if (selectedItem != null)
            {
                selectedItem.Name = updatedData.Name;
                return new Response<Item>(selectedItem, true, "Item'ı güncelledin tebriks cnm");
            }

            return new Response<Item>(null, false, "Item yok yok.");
        }
        public Response<Item> DeleteItem(int id)
        {
         var selectedItem = _items.FirstOrDefault(x => x.Id == id);
            if (selectedItem != null)
            {
                _items.Remove(selectedItem);
                return new Response<Item>(selectedItem, true, "Item başarıyla silindi");
            }

            return new Response<Item>(null, false, "Item yok yok.");
        }

       

       
    }
}
