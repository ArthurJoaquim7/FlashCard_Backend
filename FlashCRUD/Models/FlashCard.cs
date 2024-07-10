using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace FlashCRUD.Models
{
    public class FlashCard
    {
        [Key]
        public int Id { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
    }
}
