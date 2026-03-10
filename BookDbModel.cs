using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookDbApi.DbModels
{
    public class Authors
    {
        [Key]
        public int AuthorID { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorBiography { get; set; }
        public DateOnly? AuthorBirthDate { get; set; }
    }

    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }

    public class Publishers
    {
        [Key]
        public int PublisherID { get; set; }
        public string? PublisherName { get; set; }
        public string? PublisherAddress { get; set; }
        public string? PublisherWebsite { get; set; }
    }

    public class Books
    {
        [Key]
        public int BookID { get; set; }
        public string? BookTitle { get; set; }

        [ForeignKey("Authors")]
        public int AuthorID { get; set; }
        public virtual Authors? Authors { get; set; }

        [ForeignKey("Publishers")]
        public int PublisherID { get; set; }
        public virtual Publishers? Publishers { get; set; }

        [ForeignKey("Categories")]
        public int CategoryID { get; set; }
        public virtual Categories? Categories { get; set; }

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
