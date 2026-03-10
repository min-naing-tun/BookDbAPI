namespace BookDbApi.DbModels
{
    public class Authors
    {
        public int AuthorID { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorBiography { get; set; }
        public DateOnly AuthorBirthDate { get; set; }
    }

    public class Categories
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }

    public class Publishers
    {
        public int PublisherID { get; set; }
        public string? PublisherName { get; set; }
        public string? PublisherAddress { get; set; }
        public string? PublisherWebsite { get; set; }
    }

    public class Books
    {
        public int BookID { get; set; }
        public string? BookTitle { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
