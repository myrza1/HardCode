using System.ComponentModel.DataAnnotations;

namespace HardCode.Models
{
    public class JekeSostav
    {
        public int Id { get; set; }
        public string? FIO { get; set; }
        public string? Doljnost { get; set; }
        public string? Education { get; set; }



        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Date)]
        public DateTime InviteMonthYear { get; set; }


        public string? Sinyptilik { get; set; }
        public string? Eskertpe { get; set; }
    }
}
