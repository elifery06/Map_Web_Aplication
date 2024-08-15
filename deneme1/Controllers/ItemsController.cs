using deneme1.Models;
using deneme1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace deneme1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public Response<List<Item>> GetAllItems()
        {
            var items = _itemService.GetAllItems();
            return new Response<List<Item>>(items, true, "Öge baþarýyla alýndý");
        }

        [HttpGet("{id}")]
        public Response<Item> GetItem(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return new Response<Item>(null, false, "Item bulunamadý");
            }
            return new Response<Item>(item, true, "Öge baþarýyla alýndý");
        }

        [HttpPost]
        public Response<Item> Add([FromBody] Item item)
        {
            return _itemService.AddItem(item);
        }

        [HttpPut("{id}")]
        public Response<Item> Update(int id, [FromBody] Item updatedData)
        {
            return _itemService.UpdateItem(id, updatedData);
        }

        [HttpDelete("{id}")]
        public Response<Item> Delete(int id)
        {
            return _itemService.DeleteItem(id);
        }
    }
}
//using deneme1.Models;
//using deneme1.Services;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;

//namespace deneme1.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class HomeController : ControllerBase
//    {
//        //value,dönüþüm deðerleri deðerin içeriði için kullan. t/f
//        //result iþlemin çalýþýp çalýþmadýðný sorgulayan t/f bolleane
//        //message ,string , iþle olumluysa baþarýlý mesajý olumsuzsa hata mesajý
//        //ýnterfsce oluþtur
//        //servis yaz
//        private readonly IItemService _itemService;

//        static List<Item> _items = new List<Item>();

//        [HttpGet]
//        public Response<List<Item>> GetAllItems()
//        {
//            return new Response<List<Item>>(_items, true, "ögeler alýndý");
//        }

//        [HttpGet("{id}")]
//        public Response<Item> GetItem(int id)
//        {
//            var item = _items.FirstOrDefault(i => i.Id == id);
//            if (item == null)
//            {
//                return new Response<Item>(null, false, "Item bulunamadý");
//            }

//            return new Response<Item>(item, true, "Öge baþarýyla alýndý");
//        }

//        [HttpPost]
//        public Response<Item> Add([FromBody] Item item)
//        {
//            _items.Add(item);
//            return new Response<Item>(item, true, "Item baþarýyla eklendi");
//        }

//        [HttpPut("{id}")]
//        public Response<Item> Update(int id, [FromBody] Item updatedData)
//        {
//            var selectedItem = _items.FirstOrDefault(x => x.Id == id);
//            if (selectedItem != null)
//            {
//                selectedItem.Name = updatedData.Name;
//                return new Response<Item>(selectedItem, true, "Item'ý güncelledin tebriks cnm");
//            }

//            return new Response<Item>(null, false, "Item yok yok.");
//        }

//        [HttpDelete("{id}")]
//        public Response<Item> Delete(int id)
//        {
//            var selectedItem = _items.FirstOrDefault(x => x.Id == id);
//            if (selectedItem == null)
//            {
//                return new Response<Item>(null, false, "Itemý kaçýrmýþlar");
//            }

//            _items.Remove(selectedItem);
//            return new Response<Item>(null, true, "Itemý sonsuza kadar sildin");
//        }
//    }
//}
