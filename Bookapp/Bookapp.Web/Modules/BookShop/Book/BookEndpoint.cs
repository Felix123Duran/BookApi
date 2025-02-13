using Bookapp.Modules.BookShop.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
using Newtonsoft.Json;
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
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
                [FromServices] IBookSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBookSaveHandler handler)
        {
            return handler.Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IBookDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBookRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost, AuthorizeList(typeof(MyRow))]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IBookListHandler handler)
        {
            return handler.List(connection, request);
        }

        [HttpPost, AuthorizeList(typeof(MyRow))]
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IBookListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.BookColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "BookList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        public async Task<BookParametros> ejecutarAPI(BooksRequest book)
        {
            var client = new HttpClient();
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var endpointAPI = builder.GetSection("BooksAPI:endpointAPI").Value;
            var bookRequest = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var responseBook = await client.GetAsync(endpointAPI);

            if (responseBook.IsSuccessStatusCode)
            {
                var jsonBook = await responseBook.Content.ReadAsStringAsync();

                var objBooks = JsonConvert.DeserializeObject<BookParametros>(jsonBook);


                return objBooks;

            }
            else
            {
                return null;
            }

            


            //return responseBook;

        }
        
        //public async 
    }
}
