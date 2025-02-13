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
using System.Net.Http.Json;
using System.Threading.Tasks;
using MyRow = Bookapp.BookShop.BookRow;

namespace Bookapp.BookShop.Endpoints
{
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
                var createdBook = await response.Content.ReadFromJsonAsync<MyRow>();
                return new SaveResponse { EntityId = createdBook?.Id ?? 0 };
            }
            throw new ValidationError("Error al crear el libro en la FakeAPI.");
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public async Task<SaveResponse> Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            int bookId = Convert.ToInt32(request.EntityId); // Conversión segura de EntityId a int

            var response = await _httpClient.PutAsJsonAsync($"api/v1/Books/{bookId}", request.Entity);
            if (response.IsSuccessStatusCode)
            {
                return new SaveResponse { EntityId = bookId };
            }
            throw new ValidationError("Error al actualizar el libro en la FakeAPI.");
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public async Task<DeleteResponse> Delete(IUnitOfWork uow, DeleteRequest request)
        {
            int bookId = Convert.ToInt32(request.EntityId); // Conversión segura

            var response = await _httpClient.DeleteAsync($"api/v1/Books/{bookId}");
            if (response.IsSuccessStatusCode)
            {
                return new DeleteResponse();
            }
            throw new ValidationError("Error al eliminar el libro en la FakeAPI.");
        }

        [HttpPost]
        public async Task<RetrieveResponse<MyRow>> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            int bookId = Convert.ToInt32(request.EntityId); // Conversión segura

            var response = await _httpClient.GetAsync($"api/v1/Books/{bookId}");
            if (response.IsSuccessStatusCode)
            {
                var book = await response.Content.ReadFromJsonAsync<MyRow>();
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
                var books = await response.Content.ReadFromJsonAsync<List<MyRow>>();
                return new ListResponse<MyRow> { Entities = books ?? new List<MyRow>() };
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
                var books = await response.Content.ReadFromJsonAsync<List<MyRow>>();
                var bytes = exporter.Export(books ?? new List<MyRow>(), typeof(Columns.BookColumns), request.ExportColumns);

                return ExcelContentResult.Create(bytes, "BookList_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
            }
            throw new ValidationError("Error al obtener los libros desde la FakeAPI.");
        }

        //public async 
    }
}
