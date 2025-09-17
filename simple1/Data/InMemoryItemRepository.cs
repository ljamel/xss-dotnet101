namespace SimpleSearchSite.Data;


public class InMemoryItemRepository : IItemRepository
{
private readonly List<Item> _items = new()
{
new Item(1, "Apple MacBook Pro", "Laptop Apple 14 inch M2"),
new Item(2, "Dell XPS 13", "Ultrabook with Intel CPU"),
new Item(3, "Lenovo ThinkPad", "Business laptop, durable"),
new Item(4, "Samsung Galaxy S23", "Android phone"),
new Item(5, "Google Pixel 8", "Android phone by Google"),
new Item(6, "Sony WH-1000XM5", "Noise-cancelling headphones"),
new Item(7, "Apple iPhone 15", "Smartphone from Apple"),
};


public IEnumerable<Item> GetAll() => _items;


public IEnumerable<Item> Search(string query)
{
if (string.IsNullOrWhiteSpace(query)) return _items;
query = query.Trim();
// simple case-insensitive substring search on title and description
return _items.Where(i => i.Title.Contains(query, StringComparison.OrdinalIgnoreCase)
|| i.Description.Contains(query, StringComparison.OrdinalIgnoreCase));
}
}
