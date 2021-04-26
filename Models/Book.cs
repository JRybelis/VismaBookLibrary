
namespace Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }
        public int PublicationDate { get; set; }
        public Patron Patron { get; set; }
        public int MaxLoanPeriod { get; set; }
    
        public Book(string author,
                    string title,
                    string category,
                    string language,
                    string isbn,
                    int publicationDate,
                    int maxLoanPeriod = 60)
        {
            Author = author;
            Title = title;
            Category = category;
            Language = language;
            ISBN = isbn;
            PublicationDate = publicationDate;
            MaxLoanPeriod = maxLoanPeriod;
        }
    }
}
