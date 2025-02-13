using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Formatting; // Necesario para ReadAsAsync
using System.Threading.Tasks;
using MyRow = Bookapp.BookShop.BookRow;

namespace Bookapp.BookShop.Endpoints;

[Route("Services/BookShop/Book/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class BookEndpoint : ServiceEndpoint
{
    private readonly HttpClient _httpClient;

    public BookEndpoint(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public async Task<SaveResponse> Create(IUnitOfWork uow, SaveRequest<MyRow> request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/Books", request.Entity);
        if (response.IsSuccessStatusCode)
        {
            var createdBook = await response.Content.ReadAsAsync<MyRow>();
            return new SaveResponse { EntityId = createdBook.Id };
        }
        throw new ValidationError("Error al crear el libro en la FakeAPI.");
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public async Task<SaveResponse> Update(IUnitOfWork uow, SaveRequest<MyRow> request)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/v1/Books/{request.EntityId}", request.Entity);
        if (response.IsSuccessStatusCode)
        {
            return new SaveResponse { EntityId = request.EntityId };
        }
        throw new ValidationError("Error al actualizar el libro en la FakeAPI.");
    }

    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public async Task<DeleteResponse> Delete(IUnitOfWork uow, DeleteRequest request)
    {
        var response = await _httpClient.DeleteAsync($"api/v1/Books/{request.EntityId}");
        if (response.IsSuccessStatusCode)
        {
            return new DeleteResponse();
        }
        throw new ValidationError("Error al eliminar el libro en la FakeAPI.");
    }

    [HttpPost]
    public async Task<RetrieveResponse<MyRow>> Retrieve(IDbConnection connection, RetrieveRequest request)
    {
        var response = await _httpClient.GetAsync($"api/v1/Books/{request.EntityId}");
        if (response.IsSuccessStatusCode)
        {
            var book = await response.Content.ReadAsAsync<MyRow>();
            return new RetrieveResponse<MyRow> { Entity = book };
        }
        throw new ValidationError("Error al obtener el libro desde la FakeAPI.");
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public async Task<ListResponse<MyRow>> List(IDbConnection connection, ListRequest request)
    {
        var response = await _httpClient.GetAsync("api/v1/Books");
        if (response.IsSuccessStatusCode)
        {
            var books = await response.Content.ReadAsAsync<List<MyRow>>();
            return new ListResponse<MyRow> { Entities = books };
        }
        throw new ValidationError("Error al obtener los libros desde la FakeAPI.");
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public async Task<FileContentResult> ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] IExcelExporter exporter)
    {
        var response = await _httpClient.GetAsync("api/v1/Books");
        if (response.IsSuccessStatusCode)
        {
            var books = await response.Content.ReadAsAsync<List<MyRow>>();
            var bytes = exporter.Export(books, typeof(Columns.BookColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "BookList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        throw new ValidationError("Error al obtener los libros desde la FakeAPI.");
    }
}