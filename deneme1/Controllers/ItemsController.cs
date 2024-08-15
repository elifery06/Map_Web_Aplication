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
            return new Response<List<Item>>(items, true, "�ge ba�ar�yla al�nd�");
        }

        [HttpGet("{id}")]
        public Response<Item> GetItem(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return new Response<Item>(null, false, "Item bulunamad�");
            }
            return new Response<Item>(item, true, "�ge ba�ar�yla al�nd�");
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
//        //value,d�n���m de�erleri de�erin i�eri�i i�in kullan. t/f
//        //result i�lemin �al���p �al��mad��n� sorgulayan t/f bolleane
//        //message ,string , i�le olumluysa ba�ar�l� mesaj� olumsuzsa hata mesaj�
//        //�nterfsce olu�tur
//        //servis yaz
//        private readonly IItemService _itemService;

//        static List<Item> _items = new List<Item>();

//        [HttpGet]
//        public Response<List<Item>> GetAllItems()
//        {
//            return new Response<List<Item>>(_items, true, "�geler al�nd�");
//        }

//        [HttpGet("{id}")]
//        public Response<Item> GetItem(int id)
//        {
//            var item = _items.FirstOrDefault(i => i.Id == id);
//            if (item == null)
//            {
//                return new Response<Item>(null, false, "Item bulunamad�");
//            }

//            return new Response<Item>(item, true, "�ge ba�ar�yla al�nd�");
//        }

//        [HttpPost]
//        public Response<Item> Add([FromBody] Item item)
//        {
//            _items.Add(item);
//            return new Response<Item>(item, true, "Item ba�ar�yla eklendi");
//        }

//        [HttpPut("{id}")]
//        public Response<Item> Update(int id, [FromBody] Item updatedData)
//        {
//            var selectedItem = _items.FirstOrDefault(x => x.Id == id);
//            if (selectedItem != null)
//            {
//                selectedItem.Name = updatedData.Name;
//                return new Response<Item>(selectedItem, true, "Item'� g�ncelledin tebriks cnm");
//            }

//            return new Response<Item>(null, false, "Item yok yok.");
//        }

//        [HttpDelete("{id}")]
//        public Response<Item> Delete(int id)
//        {
//            var selectedItem = _items.FirstOrDefault(x => x.Id == id);
//            if (selectedItem == null)
//            {
//                return new Response<Item>(null, false, "Item� ka��rm��lar");
//            }

//            _items.Remove(selectedItem);
//            return new Response<Item>(null, true, "Item� sonsuza kadar sildin");
//        }
//    }
//}
