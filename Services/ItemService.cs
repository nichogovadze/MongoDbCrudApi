using MongoDB.Driver;
using MongoDbCrudApi.Models;

namespace MongoDbCrudApi.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemService(IConfiguration config)
        {
            var connectionString = config.GetSection("MongoDbSettings:ConnectionString").Value;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ItemDb");
            _items = database.GetCollection<Item>("Items");
        }

        public List<Item> Get() => _items.Find(item => true).ToList();

        public Item Get(string id) => _items.Find<Item>(item => item.Id == id).FirstOrDefault();

        public Item Create(Item item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, Item itemIn) => _items.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(Item itemIn) => _items.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) => _items.DeleteOne(item => item.Id == id);
    }
}