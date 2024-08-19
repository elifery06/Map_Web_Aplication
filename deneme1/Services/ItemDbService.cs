using deneme1.Data;
using deneme1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deneme1.Services
{
    public class ItemDbService:IItemService
    {
        private readonly ItemDB _context;
        public ItemDbService(ItemDB context)
        {
            _context = context;
        }
        public List<Item> GetAllItems()
        {
            return _context.Items.FromSqlRaw("SELECT * FROM Items").ToList(); // SQL ile tüm item'ları getir
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FromSqlRaw("SELECT * FROM Items WHERE Id = {0}", id).FirstOrDefault(); // SQL ile id'ye göre item getir
        }


        public Response AddItem(Item item)
        {
            var result = _context.Database.ExecuteSqlRaw(// SQL ile item ekle
                "INSERT INTO Items (XCoordinate, YCoordinate, Name, Description) VALUES ({0}, {1}, {2}, {3})",
                item.XCoordinate, item.YCoordinate, item.Name, item.Description
            );

            if (result > 0)
            {
                return new Response(item, true, "Item başarıyla eklendi");
            }
            return new Response(null, false, "Item eklenemedi");
        }

        public Response UpdateItem(int id, Item updatedData)
        {
            var result = _context.Database.ExecuteSqlRaw(
                "UPDATE Items SET XCoordinate = {0}, YCoordinate = {1}, Name = {2}, Description = {3} WHERE Id = {4}",
                updatedData.XCoordinate, updatedData.YCoordinate, updatedData.Name, updatedData.Description, id
            );

            if (result > 0)
            {
                return new Response(updatedData, true, "Item başarıyla güncellendi");
            }
            return new Response(null, false, "Item bulunamadı.");
        }
        public Response DeleteItem(int id)
        {
            var result = _context.Database.ExecuteSqlRaw(
                "DELETE FROM Items WHERE Id = {0}", id
            );

            if (result > 0)
            {
                return new Response(null, true, "Item başarıyla silindi");
            }
            return new Response(null, false, "Item bulunamadı.");
        }




        
      
    }
}
