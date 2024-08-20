//using deneme1.Data;
//using deneme1.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace deneme1.Services
//{
//    public class ItemDbService : IItemService<Item>
//    {
//        private readonly ItemDB _context;

//        public ItemDbService(ItemDB context)
//        {
//            _context = context;
//        }

//        public List<Item> GetAllItems()
//        {
//            return _context.Items.ToList();
//        }

//        public Item GetItemById(int id)
//        {
//            return _context.Items.Find(id);
//        }

//        public Response<Item> AddItem(Item item)
//        {
//            try
//            {
//                _context.Items.Add(item);
//                _context.SaveChanges();
//                return new Response<Item>(item, true, "Item başarıyla eklendi.");
//            }
//            catch (Exception ex)
//            {
//                return new Response<Item>(null, false, $"Bir hata oluştu: {ex.Message}");
//            }
//        }

//        public Response<Item> UpdateItem(int id, Item updatedData)
//        {
//            var item = _context.Items.Find(id);
//            if (item == null)
//            {
//                return new Response<Item>(null, false, "Item bulunamadı.");
//            }

//            try
//            {
//                item.XCoordinate = updatedData.XCoordinate;
//                item.YCoordinate = updatedData.YCoordinate;
//                item.Name = updatedData.Name;
//                item.Description = updatedData.Description;

//                _context.Items.Update(item);
//                _context.SaveChanges();
//                return new Response<Item>(item, true, "Item başarıyla güncellendi.");
//            }
//            catch (Exception ex)
//            {
//                return new Response<Item>(null, false, $"Bir hata oluştu: {ex.Message}");
//            }
//        }

//        public Response<Item> DeleteItem(int id)
//        {
//            var item = _context.Items.Find(id);
//            if (item == null)
//            {
//                return new Response<Item>(null, false, "Item bulunamadı.");
//            }

//            try
//            {
//                _context.Items.Remove(item);
//                _context.SaveChanges();
//                return new Response<Item>(null, true, "Item başarıyla silindi.");
//            }
//            catch (Exception ex)
//            {
//                return new Response<Item>(null, false, $"Bir hata oluştu: {ex.Message}");
//            }
//        }
//    }
//}
