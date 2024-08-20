//using deneme1.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using deneme1.Data;

//namespace deneme1.Services
//{
//    public class ManagerDb<T> : IItemService<T> where T : Item
//    {
//        private readonly ItemDB _context;

//        public ManagerDb(ItemDB context)
//        {
//            _context = context;
//        }

//        public List<T> GetAllItems()
//        {
//            return _context.Items.OfType<T>().ToList();
//        }

//        public T GetItemById(int id)
//        {
//            return _context.Items.OfType<T>().FirstOrDefault(i => i.Id == id);
//        }

//        public Response<T> AddItem(T item)
//        {
//            try
//            {
//                _context.Items.Add(item);
//                _context.SaveChanges();
//                return new Response<T>(item, true, "Item başarıyla eklendi.");
//            }
//            catch (Exception ex)
//            {
//                return new Response<T>(null, false, $"Bir hata oluştu: {ex.Message}");
//            }
//        }

//        public Response<T> UpdateItem(int id, T updatedData)
//        {
//            var item = _context.Items.OfType<T>().FirstOrDefault(i => i.Id == id);
//            if (item == null)
//            {
//                return new Response<T>(null, false, "Item bulunamadı.");
//            }

//            try
//            {
//                item = updatedData; 
//                _context.Items.Update(item);
//                _context.SaveChanges();
//                return new Response<T>(item, true, "Item başarıyla güncellendi.");
//            }
//            catch (Exception ex)
//            {
//                return new Response<T>(null, false, $"Bir hata oluştu: {ex.Message}");
//            }
//        }

//        public Response<T> DeleteItem(int id)
//        {
//            var item = _context.Items.OfType<T>().FirstOrDefault(i => i.Id == id);
//            if (item == null)
//            {
//                return new Response<T>(null, false, "Item bulunamadı.");
//            }

//            try
//            {
//                _context.Items.Remove(item);
//                _context.SaveChanges();
//                return new Response<T>(null, true, "Item başarıyla silindi.");
//            }
//            catch (Exception ex)
//            {
//                return new Response<T>(null, false, $"Bir hata oluştu: {ex.Message}");
//            }
//        }
//    }
//}
