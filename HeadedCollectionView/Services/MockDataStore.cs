using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadedCollectionView.Models;

namespace HeadedCollectionView.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="Second category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="Second category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="Second category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Seventh item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Eight item", Description="Second category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Nineth item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Tenth item", Description="Second category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Eleventh item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Twelveth item", Description="Second category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Thirteenth item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourteenth item", Description="Second category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifteenth item", Description="First category" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixteenth item", Description="Second category" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
