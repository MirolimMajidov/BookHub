namespace BookHub.Models
{
    public class Category : IEntity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}