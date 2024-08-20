using deneme1.Models;

namespace deneme1.Services
{
    public interface IItemService<T>
    {
        List<T> GetAllItems();
        T GetItemById(int id);
        Response<T> AddItem(T item);
        Response<T> UpdateItem(int id, T updatedData);
        Response<T> DeleteItem(int id);
    }
}
