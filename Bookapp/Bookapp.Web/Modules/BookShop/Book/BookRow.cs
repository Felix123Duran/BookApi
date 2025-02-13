using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace Bookapp.BookShop;

[ConnectionKey("Default"), Module("BookShop"), TableName("book")]
[DisplayName("Book"), InstanceName("Book")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
public sealed class BookRow : Row<BookRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Id"), Column("id"), PrimaryKey, NotNull, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Title"), Column("title"), Size(45), NotNull, QuickSearch, NameProperty]
    public string Title { get => fields.Title[this]; set => fields.Title[this] = value; }

    [DisplayName("Description"), Column("description"), Size(45), NotNull]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Page Count"), Column("pageCount")]
    public int? PageCount { get => fields.PageCount[this]; set => fields.PageCount[this] = value; }

    [DisplayName("Publish Date"), Column("publishDate"), NotNull]
    public DateTime? PublishDate { get => fields.PublishDate[this]; set => fields.PublishDate[this] = value; }

    [DisplayName("Excerpt"), Column("excerpt"), Size(45), NotNull]
    public string Excerpt { get => fields.Excerpt[this]; set => fields.Excerpt[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Title;
        public StringField Description;
        public Int32Field PageCount;
        public DateTimeField PublishDate;
        public StringField Excerpt;

    }
}