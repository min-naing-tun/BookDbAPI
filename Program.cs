using BookDbApi;
using BookDbApi.DbModels;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookDbContext>(opt => opt.UseInMemoryDatabase("BookDbCache"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Book Db API Server is working...");


#region [ -- Authors -- ]
app.MapGet("/authors", async(BookDbContext db) =>
{
    var dt = await db.Authors.ToListAsync();
    return dt;
});

app.MapGet("/author/{id}", async (int id, BookDbContext db) =>
{
    Authors? author = await db.Authors.Where(x => x.AuthorID == id).SingleOrDefaultAsync();
    return author;
});

app.MapPost("/author", async (Authors author, BookDbContext db) =>
{
    db.Authors.Add(author);
    await db.SaveChangesAsync();

    return "insert success!";
});

app.MapPut("/author/{id}", async (int id, Authors author, BookDbContext db) =>
{
    Authors? existedAuthor = await db.Authors.Where(x => x.AuthorID == id).SingleOrDefaultAsync();
    if(existedAuthor != null)
    {
        existedAuthor.AuthorName = author.AuthorName;
        existedAuthor.AuthorBiography = author.AuthorBiography;
        existedAuthor.AuthorBirthDate = author.AuthorBirthDate;

        await db.SaveChangesAsync();

        return "update success!";
    }
    else
    {
        return "No record found to update!";
    }
});

app.MapDelete("/author/{id}", async (int id, BookDbContext db) =>
{
    Authors? author = await db.Authors.Where(x => x.AuthorID == id).SingleOrDefaultAsync();
    if(author != null)
    {
        db.Remove(author);
        await db.SaveChangesAsync();

        return "delete success!";
    }
    else
    {
        return "No record found to delete!";
    }
});
#endregion




#region [ -- Categories -- ]
app.MapGet("/categories", async (BookDbContext db) =>
{
    var dt = await db.Categories.ToListAsync();
    return dt;
});

app.MapGet("/category/{id}", async (int id, BookDbContext db) =>
{
    Categories? category = await db.Categories.Where(x => x.CategoryID == id).SingleOrDefaultAsync();
    return category;
});

app.MapPost("/category", async (Categories category, BookDbContext db) =>
{
    db.Categories.Add(category);
    await db.SaveChangesAsync();

    return "insert success!";
});

app.MapPut("/category/{id}", async(int id, Categories category, BookDbContext db) =>
{
    Categories? existedCategory = await db.Categories.Where(x => x.CategoryID == id).SingleOrDefaultAsync();
    if(existedCategory != null)
    {
        existedCategory.CategoryName = category.CategoryName;
        existedCategory.CategoryDescription = category.CategoryDescription;

        await db.SaveChangesAsync();

        return "update success!";
    }
    else
    {
        return "No record found to update!";
    }
});

app.MapDelete("/category/{id}", async(int id, BookDbContext db) =>
{
    Categories? category = await db.Categories.Where(x => x.CategoryID == id).SingleOrDefaultAsync();
    if(category != null)
    {
        db.Categories.Remove(category);
        await db.SaveChangesAsync();

        return "delete success";
    }
    else
    {
        return "No record found to delete!";
    }
});
#endregion




#region [ -- Publishers -- ]
app.MapGet("/publishers", async (BookDbContext db) =>
{
    var dt = await db.Publishers.ToListAsync();
    return dt;
});

app.MapGet("/publisher/{id}", async(int id, BookDbContext db) =>
{
    Publishers? publisher = await db.Publishers.Where(x => x.PublisherID == id).SingleOrDefaultAsync();
    return publisher;
});

app.MapPost("/publisher", async(Publishers publisher, BookDbContext db) =>
{
    db.Publishers.Add(publisher);
    await db.SaveChangesAsync();

    return "insert success!";
});

app.MapPut("/publisher/{id}", async(int id, Publishers publisher, BookDbContext db) =>
{
    Publishers? existedPublisher = await db.Publishers.Where(x => x.PublisherID == id).SingleOrDefaultAsync();
    if(existedPublisher != null)
    {
        existedPublisher.PublisherName = publisher.PublisherName;
        existedPublisher.PublisherWebsite = publisher.PublisherWebsite;
        existedPublisher.PublisherAddress = publisher.PublisherAddress;

        await db.SaveChangesAsync();

        return "update scuccess!";
    }
    else
    {
        return "No record found to update!";
    }
});

app.MapDelete("/publisher/{id}", async(int id, BookDbContext db) =>
{
    Publishers? publisher = await db.Publishers.Where(x => x.PublisherID == id).SingleOrDefaultAsync();
    if(publisher != null)
    {
        db.Publishers.Remove(publisher);
        await db.SaveChangesAsync();

        return "delete success!";
    }
    else
    {
        return "No record found to delete!";
    }
});
#endregion




#region [ -- Books -- ]
app.MapGet("/books", async (BookDbContext db) =>
{
    var dt = await db.Books.ToListAsync();
    return dt;
});

app.MapGet("/book/{id}", async (int id, BookDbContext db) =>
{
    Books? book = await db.Books.Where(x => x.BookID == id).SingleOrDefaultAsync();
    return book;
});

app.MapPost("/book", async (Books book, BookDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();

    return "insert success!";
});

app.MapPut("/book/{id}", async (int id, Books book, BookDbContext db) =>
{
    Books? existedBook = await db.Books.Where(x => x.BookID == id).SingleOrDefaultAsync();
    if (existedBook != null)
    {
        existedBook.AuthorID = book.AuthorID;
        existedBook.CategoryID = book.CategoryID;
        existedBook.PublisherID = book.PublisherID;
        existedBook.BookTitle = book.BookTitle;
        existedBook.Price = book.Price;
        existedBook.StockQuantity = book.StockQuantity;

        await db.SaveChangesAsync();

        return "update scuccess!";
    }
    else
    {
        return "No record found to update!";
    }
});

app.MapDelete("/book/{id}", async (int id, BookDbContext db) =>
{
    Books? book = await db.Books.Where(x => x.BookID == id).SingleOrDefaultAsync();
    if (book != null)
    {
        db.Books.Remove(book);
        await db.SaveChangesAsync();

        return "delete success!";
    }
    else
    {
        return "No record found to delete!";
    }
});
#endregion



app.Run();
