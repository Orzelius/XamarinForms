using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gallery.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Gallery.Services {
    public class MockDataStore : IDataStore<Item> {
        readonly List<Item> items;

        public void generateFakeData() {
            var client = new HttpClient();

            var res = client.GetAsync("https://picsum.photos/v2/list");

            var images = JsonConvert.DeserializeObject<ApiImage[]>(res.Result.Content.ReadAsStringAsync().Result);

            for(int x = 0; x < 3 && x < images.Length; x++) {
                items.Add(new Item() {
                    Description = images[x * 2].height + "x" + images[x].height,
                    Text = "Test image by " + images[x * 2].author,
                    ImageSource = images[x * 2].download_url
                });
            }
        }
        public MockDataStore() {
            items = new List<Item>();
            generateFakeData();
        }

        public async Task<bool> AddItemAsync(Item item) {
            items.Insert(0, item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item) {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id) {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id) {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) {
            return await Task.FromResult(items);
        }
    }

    public class ApiImage {
        public string id { get; set; }
        public string author { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
    }
}