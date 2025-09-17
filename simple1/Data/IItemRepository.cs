namespace SimpleSearchSite.Data;


public interface IItemRepository
{
IEnumerable<Item> GetAll();
IEnumerable<Item> Search(string query);
}
