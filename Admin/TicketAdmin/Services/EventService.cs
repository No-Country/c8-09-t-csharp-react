using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TicketFanAdmin.Models;

namespace TicketFanAdmin.Services
{
    public partial class EventService
    {
        private readonly HttpClient _client;
        public EventService(HttpClient client)
        {
            _client = client;
        }
        public async Task<Event> Post(Event Item)
        {
            var response = await _client.PostAsJsonAsync("api/Events", Item);
            var Result = JsonConvert.DeserializeObject<Event>(await response.Content.ReadAsStringAsync());
            return Result;
        }
        //public async Task<Client> Put(Client Item)
        //{
        //    var response = await _client.PutAsJsonAsync($"api/Clients/{Item.Id}", Item);
        //    var Result = JsonConvert.DeserializeObject<Client>(await response.Content.ReadAsStringAsync());
        //    return Result;
        //}
        public async Task<ICollection<Event>> Get()
        {
            var response = await _client.GetAsync("api/Events/admin");
            var Result = JsonConvert.DeserializeObject<ICollection<Event>>(await response.Content.ReadAsStringAsync());
            return Result;
        }
        //    public async Task<Client> GetById(int id)
        //    {
        //        var response = await _client.GetAsync("api/Clients/" + id);
        //        var Result = JsonConvert.DeserializeObject<Client>(await response.Content.ReadAsStringAsync());
        //        return Result;
        //    }
        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync("api/Events/" + id);
        }

        public async Task<User> GetDash(string email)
        {
            var response = await _client.GetAsync("api/TestUsers/GetUsersTesting?email=" + email);
            var Result = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            return Result;
        }
        public async Task<FileUploadResult> UploadFile(IBrowserFile file)
        {
            using var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(file.OpenReadStream(file.Size));
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            content.Add(content: fileContent, name: "files", fileName: file.Name);
            var response = await _client.PostAsync("api/TestGenerales/UploadFiles", content);
            var test = await response.Content.ReadAsStringAsync();
            var Result = JsonConvert.DeserializeObject<FileUploadResult>(test);
            return Result;
        }
        public class FileUploadResult
        {
            public string File { get; set; }
            public string Url { get; set; }
            public bool Success { get; set; }
        }

    }
}



