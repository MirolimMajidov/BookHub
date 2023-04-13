using System.ComponentModel.DataAnnotations;

namespace BookHub.Models
{
    public class Book : IEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
