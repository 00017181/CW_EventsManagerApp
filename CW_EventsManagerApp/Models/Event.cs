using System.ComponentModel.DataAnnotations.Schema;

namespace CW_EventsManagerApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}



