using System.ComponentModel.DataAnnotations;

namespace HardCode.Models
{
    public class Tayar
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
