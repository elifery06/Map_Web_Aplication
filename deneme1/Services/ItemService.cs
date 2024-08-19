using deneme1.Data;
using deneme1.Models;

namespace deneme1.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemDB _context;

        public ItemService(ItemDB context)
        {
            _context = context;
        }

        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == id);
        }

        public Response AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return new Response(item, true, "Item başarıyla eklendi");
        }

        public Response UpdateItem(int id, Item updatedData)
        {
            var selectedItem = _context.Items.FirstOrDefault(x => x.Id == id);
            if (selectedItem != null)
            {
                selectedItem.Name = updatedData.Name;
                selectedItem.XCoordinate = updatedData.XCoordinate;
                selectedItem.YCoordinate = updatedData.YCoordinate;
                selectedItem.Description = updatedData.Description;

                _context.SaveChanges();
                return new Response(selectedItem, true, "Item başarıyla güncellendi");
            }

            return new Response(null, false, "Item bulunamadı.");
        }


        public Response DeleteItem(int id)
        {
            var selectedItem = _context.Items.FirstOrDefault(x => x.Id == id);
            if (selectedItem != null)
            {
                _context.Items.Remove(selectedItem);
                _context.SaveChanges();
                return new Response(selectedItem, true, "Item başarıyla silindi");
            }

            return new Response(null, false, "Item bulunamadı.");
        }
    }
}










