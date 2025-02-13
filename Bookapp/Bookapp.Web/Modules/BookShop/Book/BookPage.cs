using Microsoft.AspNetCore.Mvc;
using Serenity.Web;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bookapp.BookShop.Pages;

[PageAuthorize(typeof(BookRow))]
public class BookPage(HttpClient httpClient) : Controller
{
    [Route("BookShop/Book")]
    public ActionResult Index()
    {
        return this.GridPage("@/BookShop/Book/BookPage",
            BookRow.Fields.PageTitle());
    }

    [HttpGet]
    public async Task<ListResponse<BookRow>> List()
    {
        var response = await httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");
        if (response.IsSuccessStatusCode)
        {
            var books = await response.Content.ReadFromJsonAsync<List<BookRow>>();
            return new ListResponse<BookRow> { Entities = books ?? new List<BookRow>() };
        }
        throw new ValidationError("Error al obtener los libros desde la FakeAPI.");
    }

    [HttpGet]
    public async Task<RetrieveResponse<BookRow>> Retrieve(int id)
    {
        var response = await httpClient.GetAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}");
        if (response.IsSuccessStatusCode)
        {
            var book = await response.Content.ReadFromJsonAsync<BookRow>();
            return new RetrieveResponse<BookRow> { Entity = book };
        }
        throw new ValidationError("Error al obtener el libro desde la FakeAPI.");
    }

    [HttpPost]
    public async Task<SaveResponse> Create(SaveRequest<BookRow> request)
    {
        var response = await httpClient.PostAsJsonAsync("https://fakerestapi.azurewebsites.net/api/v1/Books", request.Entity);
        if (response.IsSuccessStatusCode)
        {
            var createdBook = await response.Content.ReadFromJsonAsync<BookRow>();
            return new SaveResponse { EntityId = createdBook?.Id ?? 0 }; // Manejo seguro de nulos
        }
        throw new ValidationError("Error al crear el libro en la FakeAPI.");
    }

    [HttpPut]
    public async Task<SaveResponse> Update(SaveRequest<BookRow> request)
    {
        int bookId = Convert.ToInt32(request.EntityId); // Conversión segura

        var response = await httpClient.PutAsJsonAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{bookId}", request.Entity);
        if (response.IsSuccessStatusCode)
        {
            return new SaveResponse { EntityId = bookId };
        }
        throw new ValidationError("Error al actualizar el libro en la FakeAPI.");
    }

    [HttpDelete]
    public async Task<DeleteResponse> Delete(DeleteRequest request)
    {
        int bookId = Convert.ToInt32(request.EntityId); // Conversión segura

        var response = await httpClient.DeleteAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{bookId}");
        if (response.IsSuccessStatusCode)
        {
            return new DeleteResponse();
        }
        throw new ValidationError("Error al eliminar el libro en la FakeAPI.");
    }
}
