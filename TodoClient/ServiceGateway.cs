using RestSharp;

namespace TodoClient
{
    public class ServiceGateway
    {
        // The base address of the Todo Api may vary whether you run
        // the project on the built-in Kestrel web server or IIS Express
        // (the last one is only available if you are running Visual
        // Studio on Windows)
        const string baseAddress = "https://localhost:5001/Todo";

        RestClient c = new RestClient(baseAddress);


        public async Task<IEnumerable<TodoItem>> GetItemsAsync()
        {
            var request = new RestRequest();
            var items = await c.GetAsync<List<TodoItem>>(request);
            return items;
        }

        public async Task<TodoItem> GetItemAsync(long id)
        {
            var request = new RestRequest(id.ToString());
            var item = await c.GetAsync<TodoItem>(request);
            return item;
        }
        
        public async Task<bool> CreateItemAsync(TodoItem item)
        {
            var request = new RestRequest();
            request.AddJsonBody(item);
            var response = await c.PostAsync(request);
            return response.IsSuccessful;
        }

        public async Task<bool> UpdateItemAsync(TodoItem item)
        {
            var request = new RestRequest(item.Id.ToString());
            request.AddJsonBody(item);
            var response = await c.PutAsync(request);
            return response.IsSuccessful;
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            var request = new RestRequest(id.ToString());
            var response = await c.DeleteAsync(request);
            return response.IsSuccessful;
        }
    }
}
