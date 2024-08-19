using deneme1.Data;
using deneme1.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace deneme1.Services
{
    public class ManagerDb : IItemService
    {
        private readonly ItemDB _context;

        public ManagerDb(ItemDB context)
        {
            _context = context;
        }

        public List<Item> GetAllItems()
        {
            // Entity Framework Core kullanarak tüm item'ları getir
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            // Entity Framework Core kullanarak ID'ye göre item getir
            return _context.Items.Find(id);
        }

        public Response AddItem(Item item)
        {
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return new Response(item, true, "Item başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return new Response(null, false, $"Bir hata oluştu: {ex.Message}");
            }
        }

        public Response UpdateItem(int id, Item updatedData)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return new Response(null, false, "Item bulunamadı.");
            }

            try
            {
                item.XCoordinate = updatedData.XCoordinate;
                item.YCoordinate = updatedData.YCoordinate;
                item.Name = updatedData.Name;
                item.Description = updatedData.Description;

                _context.Items.Update(item);
                _context.SaveChanges();
                return new Response(item, true, "Item başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return new Response(null, false, $"Bir hata oluştu: {ex.Message}");
            }
        }

        public Response DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                return new Response(null, false, "Item bulunamadı.");
            }

            try
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
                return new Response(item, true, "Item başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return new Response(null, false, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}




//public async Task<List<Item>> GetAllItemsAsync()
//{
//    return await _context.Items.ToListAsync();//Items tablosundaki tüm verileri getirir
//}

//public async Task<Item> GetItemByIdAsync(int id)
//{
//    return await _context.Items.FindAsync(id);//Items tablosundan id'ye göre veri getirir
//}
//public async Task<Response> AddItemAsync(Item item)
//{
//    try
//    {
//        await _context.Items.AddAsync(item);
//        await _context.SaveChangesAsync();
//        return new Response(item, true, "Item başarıyla eklendi.");
//    }
//    catch (Exception ex)
//    {
//        return new Response(null, false, $"Bir hata oluştu: {ex.Message}");
//    }
//}

//public async Task<Response> UpdateItemAsync(int id, Item updatedItem)
//{
//    var item = await _context.Items.FindAsync(id);
//    if (item == null)
//    {
//        return new Response(null, false, "Item bulunamadı.");
//    }

//    try
//    {
//        item.XCoordinate = updatedItem.XCoordinate;
//        item.YCoordinate = updatedItem.YCoordinate;
//        item.Name = updatedItem.Name;
//        item.Description = updatedItem.Description;

//        _context.Items.Update(item);
//        await _context.SaveChangesAsync();
//        return new Response(item, true, "Item başarıyla güncellendi.");
//    }
//    catch (Exception ex)
//    {
//        return new Response(null, false, $"Bir hata oluştu: {ex.Message}");
//    }
//}

//public async Task<Response> DeleteItemAsync(int id)
//{
//    var item = await _context.Items.FindAsync(id);
//    if (item == null)
//    {
//        return new Response(null, false, "Item bulunamadı.");
//    }

//    try
//    {
//        _context.Items.Remove(item);
//        await _context.SaveChangesAsync();
//        return new Response(item, true, "Item başarıyla silindi.");
//    }
//    catch (Exception ex)
//    {
//        return new Response(null, false, $"Bir hata oluştu: {ex.Message}");
//    }
//}



